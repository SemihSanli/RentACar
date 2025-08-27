using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.CarQueries;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.CarResults;
using CQRS_MediatR_RentACar.DataAccessLayer.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Handlers.CarHandlers
{
    public class GetCarsByBrandQueryHandler : IRequestHandler<GetCarsByBrandQuery, List<GetCarQueryResult>>
    {
        private readonly ICarDal _carDal;

        public GetCarsByBrandQueryHandler(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public async Task<List<GetCarQueryResult>> Handle(GetCarsByBrandQuery request, CancellationToken cancellationToken)
        {
            var cars = string.IsNullOrEmpty(request.CarBrand)
                ? await _carDal.GetListAsync()
                : await _carDal.GetCarsByBrandAsync(request.CarBrand);

            return cars.Select(c => new GetCarQueryResult
            {
                CarBrand = c.CarBrand,
                CarFuel = c.CarFuel,
                CarID = c.CarID,
                CarKM = c.CarKM,
                CarPrice = c.CarPrice,
                CarModel = c.CarModel,
                CarImageURL = c.CarImageURL,
                CarSeat = c.CarSeat,
                CarReview = c.CarReview,
                CarTransmission = c.CarTransmission,
                CarYear = c.CarYear,
                IsAutoOrManual = c.IsAutoOrManual,
            }).ToList();
                
        }
    }
}
