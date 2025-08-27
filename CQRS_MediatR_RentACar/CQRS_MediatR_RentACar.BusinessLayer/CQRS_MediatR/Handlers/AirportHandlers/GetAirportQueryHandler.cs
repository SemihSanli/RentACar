using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.AirportQueries;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.AboutResults;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.AirportResults;
using CQRS_MediatR_RentACar.DataAccessLayer.Abstract;
using CQRS_MediatR_RentACar.DataAccessLayer.EntityFramework;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Handlers.AirportHandlers
{
    public class GetAirportQueryHandler : IRequestHandler<GetAirportQuery, List<GetAirportQueryResult>>
    {
        private readonly IAirportDal _airportDal;

        public GetAirportQueryHandler(IAirportDal airportDal)
        {
            _airportDal = airportDal;
        }

        public async Task<List<GetAirportQueryResult>> Handle(GetAirportQuery request, CancellationToken cancellationToken)
        {
            var values = await _airportDal.GetListAsync();
            return values.Select(x => new GetAirportQueryResult
            {
               AirportID = x.AirportID,
               Dst  = x.Dst,
               Elevation = x.Elevation,
               Iata = x.Iata,
               Icao = x.Icao,
               Latitude = x.Latitude,
               Longitude = x.Longitude,
               Name = x.Name,
               Timezone = x.Timezone,
               Utc_offset  =x.Utc_offset
            }).ToList();
        }
    }
}
