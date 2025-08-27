using CQRS_MediatR_RentACar.BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.Services
{
    public class CarRecommendationAIService : ICarRecommendationAIService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "YOUR_API_KEY";
        public CarRecommendationAIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GenerateCarRecommendation(string customerPrompt, int responseNumber)
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _apiKey);
            var systemPrompt = responseNumber switch
            {
                1 => "You are a car rental expert. Provide a practical, budget-friendly car recommendation based on the customer's needs. Be concise and helpful.",
                2 => "You are a luxury car specialist. Suggest premium or mid-range car options that would enhance the customer's experience. Be persuasive but realistic.",
                3 => "You are a car safety and comfort advisor. Focus on safety features, comfort, and reliability when recommending a vehicle. Be informative and reassuring."
            };
            var requestBody = new
            {
                model = "gpt-4o-mini",
                messages = new[]
                {
                    new { role = "system", content = systemPrompt },
                    new { role = "user", content = $"Customer request: {customerPrompt}. Please provide car recommendation #{responseNumber}." }

                }
            };
            var response = await _httpClient.PostAsJsonAsync("https://api.openai.com/v1/chat/completions", requestBody);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<JsonElement>();
            return result.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();
        }
    }
}
