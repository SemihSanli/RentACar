using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.CarQueries;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.CarResults;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.TestimonialResults;
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
    public class GetCarCountQueryHandler : IRequestHandler<GetCarCountQuery, GetCarCountQueryResult>
    {
        private readonly ICarDal _carDal;

        public GetCarCountQueryHandler(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public async Task<GetCarCountQueryResult> Handle(GetCarCountQuery request, CancellationToken cancellationToken)
        {
            int count = await _carDal.GetCarCount();
            return new GetCarCountQueryResult { Count = count };
        }
    }
}
