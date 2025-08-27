using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.CarQueries;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.CarResults;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.FeatureResults;
using CQRS_MediatR_RentACar.DataAccessLayer.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Handlers.CarHandlers
{
    public class GetCarQueryHandler : IRequestHandler<GetCarQuery, List<GetCarQueryResult>>
    {
        private readonly ICarDal _carDal;

        public GetCarQueryHandler(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public async  Task<List<GetCarQueryResult>> Handle(GetCarQuery request, CancellationToken cancellationToken)
        {
            var values = await _carDal.GetListAsync();
            return values.Select(x => new GetCarQueryResult
            {
                CarImageURL = x.CarImageURL,
                CarID = x.CarID,
                CarBrand = x.CarBrand,
                CarFuel = x.CarFuel,
                CarModel = x.CarModel,
                CarPrice = x.CarPrice,
                CarKM = x.CarKM,
                CarReview = x.CarReview,
                CarSeat = x.CarSeat,
                CarTransmission = x.CarTransmission,
                CarYear = x.CarYear,
                IsAutoOrManual = x.IsAutoOrManual,
            }).ToList();
        }
    }
}
