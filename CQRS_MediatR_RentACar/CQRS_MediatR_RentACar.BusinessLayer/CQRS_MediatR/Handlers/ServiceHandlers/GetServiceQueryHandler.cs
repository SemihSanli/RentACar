using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.ServiceQueries;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.FeatureResults;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.ServiceResults;
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
    public class GetServiceQueryHandler : IRequestHandler<GetServiceQuery, List<GetServiceQueryResult>>
    {
        private readonly IServiceDal _serviceDal;

        public GetServiceQueryHandler(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }

        public async Task<List<GetServiceQueryResult>> Handle(GetServiceQuery request, CancellationToken cancellationToken)
        {
            var values = await _serviceDal.GetListAsync();
            return values.Select(x => new GetServiceQueryResult
            {
                ServiceIconURL = x.ServiceIconURL,
                ServiceArticleDescription = x.ServiceArticleDescription,
                ServiceArticleTitle = x.ServiceArticleTitle,
                ServiceEntryTitle = x.ServiceEntryTitle,
                ServiceID = x.ServiceID
            }).ToList();
        }
    }
}
