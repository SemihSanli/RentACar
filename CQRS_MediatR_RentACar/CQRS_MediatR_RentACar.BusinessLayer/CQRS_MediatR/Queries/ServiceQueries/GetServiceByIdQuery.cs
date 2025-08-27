using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.ServiceResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.ServiceQueries
{
    public class GetServiceByIdQuery:IRequest<GetServiceByIdQueryResult>
    {
        public int ServiceID { get; set; }

        public GetServiceByIdQuery(int serviceID)
        {
            ServiceID = serviceID;
        }
    }
}
