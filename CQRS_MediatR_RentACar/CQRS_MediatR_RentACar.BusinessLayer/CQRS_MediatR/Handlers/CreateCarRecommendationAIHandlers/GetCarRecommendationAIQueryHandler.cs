using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.CarRecommendationAIQueries;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.CarRecommendationAIResults;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.ContactResults;
using CQRS_MediatR_RentACar.DataAccessLayer.Abstract;
using CQRS_MediatR_RentACar.DataAccessLayer.EntityFramework;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Handlers.CreateCarRecommendationAIHandlers
{
    public class GetCarRecommendationAIQueryHandler : IRequestHandler<GetCarRecommendationAIQuery, List<GetCarRecommendationAIQueryResult>>
    {
        private readonly ICarRecommendationAIDal _carRecommendationAIDal;

        public GetCarRecommendationAIQueryHandler(ICarRecommendationAIDal carRecommendationAIDal)
        {
            _carRecommendationAIDal = carRecommendationAIDal;
        }

        public async Task<List<GetCarRecommendationAIQueryResult>> Handle(GetCarRecommendationAIQuery request, CancellationToken cancellationToken)
        {
            var values = await _carRecommendationAIDal.GetListAsync();
            return values.Select(x => new GetCarRecommendationAIQueryResult
            {
               CarRecommendationAIID = x.CarRecommendationAIID,
               CustomerPrompt = x.CustomerPrompt,
               AIResponse1 = x.AIResponse1,
               AIResponse2 = x.AIResponse2,
               AIResponse3 = x.AIResponse3,
               ResponseDate=DateTime.Now
            }).ToList();
        }
    }
}
