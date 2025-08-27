using CQRS_MediatR_RentACar.UILayer.DTOs.CityDTOs;
using System.Net.Http.Headers;
using System.Text.Json;

namespace CQRS_MediatR_RentACar.UILayer.RapidApiServices.CityAPI
{
    public class LocationRapidApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _endpoint;

        public LocationRapidApiClient(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _endpoint = config["RapidApi2:Endpoint2"]; 
            var key = config["RapidApi2:Key2"];
            var host = config["RapidApi2:Host2"];
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", key);
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", host);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<CityRapidApiDTO>> GetCitiesAsync(string countryCode = "tr")
        {
            var url = string.IsNullOrWhiteSpace(countryCode) ? _endpoint : $"{_endpoint}?countrycode={countryCode}";
            var resp = await _httpClient.GetAsync(url);
            resp.EnsureSuccessStatusCode();

            var stream = await resp.Content.ReadAsStreamAsync();
            var dto = await JsonSerializer.DeserializeAsync<List<CityRapidApiDTO>>(stream, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return dto ?? new List<CityRapidApiDTO>();
        }
    }
}
