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
    public class GetLast4QueryHandler : IRequestHandler<GetLast4CarQuery, List<GetLast4CarQueryResult>>
    {
        private readonly ICarDal _carDal;

        public GetLast4QueryHandler(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public async Task<List<GetLast4CarQueryResult>> Handle(GetLast4CarQuery request, CancellationToken cancellationToken)
        {
            var values = await _carDal.GetLast4CarAsync();
            return values.Select(x => new GetLast4CarQueryResult
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
