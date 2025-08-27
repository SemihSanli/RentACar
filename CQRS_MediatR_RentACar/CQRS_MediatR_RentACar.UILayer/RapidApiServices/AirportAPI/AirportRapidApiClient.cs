using CQRS_MediatR_RentACar.UILayer.DTOs.AirportDTOs;
using System.Net.Http.Headers;
using System.Text.Json;

namespace CQRS_MediatR_RentACar.UILayer.RapidApiServices.AirportAPI
{

    public class AirportRapidApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _endpoint;

        public AirportRapidApiClient(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _endpoint = config["RapidApi:Endpoint"];
            var key = config["RapidApi:Key"];
            var host = config["RapidApi:Host"];
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", key);
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", host);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<AirportRapidApiDTO.Rootobject> GetAirportsAsync(string queryParams = "")
        {
            var url = string.IsNullOrWhiteSpace(queryParams) ? _endpoint : $"{_endpoint}?{queryParams}";
            var resp = await _httpClient.GetAsync(url);
            resp.EnsureSuccessStatusCode();
            var stream = await resp.Content.ReadAsStreamAsync();
            var dto = await JsonSerializer.DeserializeAsync<AirportRapidApiDTO.Rootobject>(stream, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return dto;
        }
    }

}
