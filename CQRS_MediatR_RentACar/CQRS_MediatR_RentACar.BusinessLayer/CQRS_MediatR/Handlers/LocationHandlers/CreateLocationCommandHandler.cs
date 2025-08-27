using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Commands.LocationCommands;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.LocationQueries;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.LocationResults;
using CQRS_MediatR_RentACar.DataAccessLayer.Abstract;
using CQRS_MediatR_RentACar.DataAccessLayer.EntityFramework;
using CQRS_MediatR_RentACar.EntityLayer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Handlers.LocationHandlers
{
    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand>
    {
        private readonly ILocationDal _locationDal;

        public CreateLocationCommandHandler(ILocationDal locationDal)
        {
            _locationDal = locationDal;
        }

        public async Task Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            await _locationDal.InsertAsync(new Location
            {
               Latitude = request.Latitude,
               Longitude = request.Longitude,
               CountryCode = request.CountryCode,
               Name = request.Name,
               StateCode = request.StateCode
            });
        }
    }
}
