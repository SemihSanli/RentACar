using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.ServiceQueries;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.ServiceResults;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.TestimonialResults;
using CQRS_MediatR_RentACar.DataAccessLayer.Abstract;
using CQRS_MediatR_RentACar.DataAccessLayer.EntityFramework;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Handlers.ServiceHandlers
{
    public class GetServiceCountQueryHandler : IRequestHandler<GetServiceCountQuery, GetServiceCountQueryResult>
    {
        private readonly IServiceDal _serviceDal;

        public GetServiceCountQueryHandler(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }

        public async Task<GetServiceCountQueryResult> Handle(GetServiceCountQuery request, CancellationToken cancellationToken)
        {

            int count = await _serviceDal.ServiceCount();
            return new GetServiceCountQueryResult { Count = count };
        }
    }
}
