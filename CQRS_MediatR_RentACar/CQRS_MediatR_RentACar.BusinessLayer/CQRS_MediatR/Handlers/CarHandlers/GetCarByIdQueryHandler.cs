using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.CarQueries;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.CarResults;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.StaffResults;
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
    public class GetCarByIdQueryHandler : IRequestHandler<GetCarByIdQuery, GetCarByIdQueryResult>
    {
        private readonly ICarDal _carDal;

        public GetCarByIdQueryHandler(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _carDal.GetByIdAsync(request.CarID);
            return new GetCarByIdQueryResult
            {
                CarID = values.CarID,
                CarBrand = values.CarBrand,
                CarFuel = values.CarFuel,
                CarImageURL = values.CarImageURL,
                CarKM = values.CarKM,
                CarModel = values.CarModel,
                CarPrice = values.CarPrice,
                CarReview = values.CarReview,
                CarSeat = values.CarSeat,
                CarTransmission = values.CarTransmission,
                CarYear = values.CarYear,
                IsAutoOrManual = values.IsAutoOrManual,
            };
        }
    }
}
