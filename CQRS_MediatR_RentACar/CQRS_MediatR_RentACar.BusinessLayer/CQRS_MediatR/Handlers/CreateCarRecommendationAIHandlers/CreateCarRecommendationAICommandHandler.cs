using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Commands.CarRecommendationAICommands;
using CQRS_MediatR_RentACar.BusinessLayer.Interfaces;
using CQRS_MediatR_RentACar.DataAccessLayer.Abstract;
using CQRS_MediatR_RentACar.EntityLayer;
using MediatR;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Handlers.CreateCarRecommendationAIHandlers
{
    public class CreateCarRecommendationAICommandHandler : IRequestHandler<CreateCarRecommendationAICommand>
    {
        private readonly ICarRecommendationAIDal _carRecommendationAIDal;
        private readonly ICarRecommendationAIService _carRecommendationAIService;
        public CreateCarRecommendationAICommandHandler(ICarRecommendationAIDal carRecommendationAIDal, ICarRecommendationAIService carRecommendationAIService)
        {
            _carRecommendationAIDal = carRecommendationAIDal;
            _carRecommendationAIService = carRecommendationAIService;
        }

        public async Task Handle(CreateCarRecommendationAICommand request, CancellationToken cancellationToken)
        {

            var aiResponse1 = await _carRecommendationAIService.GenerateCarRecommendation(request.CustomerPrompt, 1);
            var aiResponse2 = await _carRecommendationAIService.GenerateCarRecommendation(request.CustomerPrompt, 2);
            var aiResponse3 = await _carRecommendationAIService.GenerateCarRecommendation(request.CustomerPrompt, 3);

            var carRecommendation = new CarRecommendationAI
            {
                CustomerPrompt = request.CustomerPrompt,
                AIResponse1 = aiResponse1,
                AIResponse2 = aiResponse2,
                AIResponse3 = aiResponse3,
                ResponseDate = DateTime.Now,
            };
            await _carRecommendationAIDal.InsertAsync(carRecommendation);
        }
       
    }
   

}
