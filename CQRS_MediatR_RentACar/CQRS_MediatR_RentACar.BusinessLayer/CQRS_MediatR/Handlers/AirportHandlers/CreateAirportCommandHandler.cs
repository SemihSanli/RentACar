using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Commands.AirportCommands;
using CQRS_MediatR_RentACar.DataAccessLayer.Abstract;
using CQRS_MediatR_RentACar.DataAccessLayer.EntityFramework;
using CQRS_MediatR_RentACar.EntityLayer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Handlers.AirportHandlers
{
    public class CreateAirportCommandHandler : IRequestHandler<CreateAirportCommand>
    {
        private readonly IAirportDal _airportDal;

        public CreateAirportCommandHandler(IAirportDal airportDal)
        {
            _airportDal = airportDal;
        }

        public async Task Handle(CreateAirportCommand request, CancellationToken cancellationToken)
        {
            await _airportDal.InsertAsync(new Airport
            {
                Dst = request.Dst,
                Elevation = request.Elevation,
                Iata = request.Iata,
                Icao = request.Icao,
                Latitude = request.Latitude,
                Longitude = request.Longitude,
                Name = request.Name,
                Timezone = request.Timezone,
                Utc_offset = request.Utc_offset,
            });
        }
    }
}
