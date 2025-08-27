using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.LocationQueries;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.LocationResults;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.TestimonialResults;
using CQRS_MediatR_RentACar.DataAccessLayer.Abstract;
using CQRS_MediatR_RentACar.DataAccessLayer.EntityFramework;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Handlers.LocationHandlers
{
    public class GetLocationCountQueryHandler : IRequestHandler<GetLocationCountQuery, GetLocationCountQueryResult>
    {
        private readonly ILocationDal _locationDal;

        public GetLocationCountQueryHandler(ILocationDal locationDal)
        {
            _locationDal = locationDal;
        }

        public async Task<GetLocationCountQueryResult> Handle(GetLocationCountQuery request, CancellationToken cancellationToken)
        {
            int count = await _locationDal.LocationCount();
            return new GetLocationCountQueryResult { Count = count };
        }
    }
}
