using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.CarRecommendationAIResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.CarRecommendationAIQueries
{
    public class GetCarRecommendationAIQuery:IRequest<List<GetCarRecommendationAIQueryResult>>
    {
    }
}
