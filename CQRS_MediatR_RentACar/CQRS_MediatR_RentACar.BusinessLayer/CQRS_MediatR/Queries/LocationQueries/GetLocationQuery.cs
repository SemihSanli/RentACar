using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.LocationResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.LocationQueries
{
    public class GetLocationQuery:IRequest<List<GetLocationQueryResult>>
    {
    }
}
