using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.LocationQueries;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.LocationResults;
using CQRS_MediatR_RentACar.DataAccessLayer.Abstract;
using MediatR;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Handlers.LocationHandlers
{
    public class GetLocationQueryHandler : IRequestHandler<GetLocationQuery, List<GetLocationQueryResult>>
    {
        private readonly ILocationDal _locationDal;

        public GetLocationQueryHandler(ILocationDal locationDal)
        {
            _locationDal = locationDal;
        }

        public async Task<List<GetLocationQueryResult>> Handle(GetLocationQuery request, CancellationToken cancellationToken)
        {
            var values = await _locationDal.GetListAsync();
            return values.Select(x => new GetLocationQueryResult
            {
                LocationID = x.LocationID,
                Name = x.Name,
                CountryCode = x.CountryCode,
                StateCode = x.StateCode,
                Latitude = x.Latitude,
                Longitude = x.Longitude
            }).ToList();
        }
    }
}



