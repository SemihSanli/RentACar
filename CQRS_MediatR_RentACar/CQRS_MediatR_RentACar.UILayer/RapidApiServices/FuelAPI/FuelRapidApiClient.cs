using System.Net.Http.Headers;
using System.Text.Json;

namespace CQRS_MediatR_RentACar.UILayer.RapidApiServices.FuelAPI
{
    public class FuelRapidApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _endpoint;

        public FuelRapidApiClient(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _endpoint = config["FuelAPI:Endpoint"];
            var key = config["FuelAPI:Key"];
            var host = config["FuelAPI:Host"];
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", key);
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", host);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<(decimal? gasoline, decimal? diesel, decimal? lpg, string? currency)> GetTurkeyPricesAsync()
        {
            var response = await _httpClient.GetAsync(_endpoint);
            if (!response.IsSuccessStatusCode)
            {
                // Gracefully handle rate limit or server errors
                return (null, null, null, null);
            }
            await using var stream = await response.Content.ReadAsStreamAsync();
            using var doc = await JsonDocument.ParseAsync(stream);

            var (gasoline, diesel, lpg, currency) = (default(decimal?), default(decimal?), default(decimal?), default(string));

            JsonElement payload = doc.RootElement;

            // handle { result: {...} } or { result: [...] }
            if (payload.ValueKind == JsonValueKind.Object && payload.TryGetProperty("result", out var resultEl))
            {
                payload = resultEl;
            }

            if (payload.ValueKind == JsonValueKind.Array)
            {
                JsonElement? best = null;
                foreach (var item in payload.EnumerateArray())
                {
                    var country = TryGetString(item, new[] { "country", "name", "countryName" });
                    var code = TryGetString(item, new[] { "code", "countryCode", "iso2" });
                    if (!string.IsNullOrWhiteSpace(country))
                    {
                        var c = country!.ToLowerInvariant();
                        if (c.Contains("turk")) { best = item; break; }
                    }
                    if (!string.IsNullOrWhiteSpace(code) && string.Equals(code, "TR", StringComparison.OrdinalIgnoreCase))
                    {
                        best = item; break;
                    }
                }
                best ??= payload.EnumerateArray().FirstOrDefault();
                if (best.HasValue)
                {
                    currency = TryGetString(best.Value, new[] { "currency", "unit", "currencyType" }) ?? "TRY";
                    gasoline = TryGetDecimal(best.Value, new[] { "gasolineTL", "gasoline", "benzin", "petrol" });
                    diesel = TryGetDecimal(best.Value, new[] { "dieselTL", "diesel", "motorin" });
                    lpg = TryGetDecimal(best.Value, new[] { "lpgTL", "lpg" });
                }
            }
            else if (payload.ValueKind == JsonValueKind.Object)
            {
                currency = TryGetString(payload, new[] { "currency", "unit", "currencyType" }) ?? "TRY";
                gasoline = TryGetDecimal(payload, new[] { "gasolineTL", "gasoline", "benzin", "petrol" });
                diesel = TryGetDecimal(payload, new[] { "dieselTL", "diesel", "motorin" });
                lpg = TryGetDecimal(payload, new[] { "lpgTL", "lpg" });
            }

            return (gasoline, diesel, lpg, string.IsNullOrWhiteSpace(currency) ? "TRY" : currency);
        }

        private static decimal? TryGetDecimal(JsonElement obj, string[] propertyNames)
        {
            foreach (var name in propertyNames)
            {
                if (obj.TryGetProperty(name, out var prop))
                {
                    switch (prop.ValueKind)
                    {
                        case JsonValueKind.Number:
                            if (prop.TryGetDecimal(out var d)) return d;
                            break;
                        case JsonValueKind.String:
                            var sVal = prop.GetString();
                            if (string.IsNullOrWhiteSpace(sVal)) break;
                            // normalize common formats (e.g., "35,42" or "35.42 TL")
                            sVal = sVal.Replace("TL", string.Empty, StringComparison.OrdinalIgnoreCase)
                                       .Replace("₺", string.Empty)
                                       .Trim();
                            if (decimal.TryParse(sVal, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out var s))
                                return s;
                            if (decimal.TryParse(sVal, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.GetCultureInfo("tr-TR"), out var sTr))
                                return sTr;
                            break;
                    }
                }
            }
            return null;
        }

        private static string? TryGetString(JsonElement obj, string[] propertyNames)
        {
            foreach (var name in propertyNames)
            {
                if (obj.TryGetProperty(name, out var prop) && prop.ValueKind == JsonValueKind.String)
                {
                    return prop.GetString();
                }
            }
            return null;
        }
    }
}


