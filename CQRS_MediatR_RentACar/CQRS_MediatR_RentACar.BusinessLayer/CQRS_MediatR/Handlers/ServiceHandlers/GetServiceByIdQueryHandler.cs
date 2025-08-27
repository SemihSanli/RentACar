using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.ServiceQueries;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.ServiceResults;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.StaffResults;
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
    public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, GetServiceByIdQueryResult>
    {
        private readonly IServiceDal _serviceDal;

        public GetServiceByIdQueryHandler(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }

        public async Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _serviceDal.GetByIdAsync(request.ServiceID);
            return new GetServiceByIdQueryResult
            {
                ServiceID = values.ServiceID,
                ServiceArticleDescription = values.ServiceArticleDescription,
                ServiceArticleTitle = values.ServiceArticleTitle,
                ServiceEntryTitle = values.ServiceEntryTitle,
                ServiceIconURL = values.ServiceIconURL,
            };
        }
    }
}
