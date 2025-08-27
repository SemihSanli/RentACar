using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.StaffResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.StaffQueries
{
    public class GetStaffByIdQuery:IRequest<GetStaffByIdQueryResult>
    {
        public int StaffID { get; set; }

        public GetStaffByIdQuery(int staffID)
        {
            StaffID = staffID;
        }
    }
}
