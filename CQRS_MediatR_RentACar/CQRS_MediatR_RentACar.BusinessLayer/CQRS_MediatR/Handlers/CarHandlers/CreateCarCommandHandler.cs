using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Commands.CarCommands;
using CQRS_MediatR_RentACar.DataAccessLayer.Abstract;
using CQRS_MediatR_RentACar.DataAccessLayer.EntityFramework;
using CQRS_MediatR_RentACar.EntityLayer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Handlers.CarHandlers
{
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand>
    {
        private readonly ICarDal _carDal;

        public CreateCarCommandHandler(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public async Task Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            await _carDal.InsertAsync(new Car
            {
                CarBrand = request.CarBrand,
                CarFuel = request.CarFuel,
                CarImageURL = request.CarImageURL,
                CarModel = request.CarModel,
                CarPrice = request.CarPrice,
                CarKM = request.CarKM,
                CarReview = request.CarReview,
                CarSeat = request.CarSeat,
                CarTransmission = request.CarTransmission,
                CarYear = request.CarYear,
                IsAutoOrManual = request.IsAutoOrManual
            });
        }
    }
}
