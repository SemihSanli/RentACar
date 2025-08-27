using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Commands.CarCommands;
using CQRS_MediatR_RentACar.DataAccessLayer.Abstract;
using CQRS_MediatR_RentACar.DataAccessLayer.EntityFramework;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand>
    {
        private readonly ICarDal _carDal;

        public UpdateCarCommandHandler(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public async Task Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            var values = await _carDal.GetByIdAsync(request.CarID);
            values.CarFuel = request.CarFuel;
            values.CarReview = request.CarReview;
            values.CarBrand = request.CarBrand;
            values.CarTransmission = request.CarTransmission;
            values.CarPrice = request.CarPrice;
            values.CarYear = request.CarYear;
            values.CarSeat = request.CarSeat;
            values.CarKM = request.CarKM;
            values.CarModel = request.CarModel;
            values.IsAutoOrManual = request.IsAutoOrManual;
        }
    }
}
