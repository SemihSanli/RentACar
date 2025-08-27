using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.StaffQueries;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.StaffResults;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.TestimonialResults;
using CQRS_MediatR_RentACar.DataAccessLayer.Abstract;
using CQRS_MediatR_RentACar.DataAccessLayer.EntityFramework;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Handlers.StaffHandlers
{
    public class GetStaffByIdQueryHandler : IRequestHandler<GetStaffByIdQuery, GetStaffByIdQueryResult>
    {
        private readonly IStaffDal _staffDal;

        public GetStaffByIdQueryHandler(IStaffDal staffDal)
        {
            _staffDal = staffDal;
        }

        public async Task<GetStaffByIdQueryResult> Handle(GetStaffByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _staffDal.GetByIdAsync(request.StaffID);
            return new GetStaffByIdQueryResult
            {
                StaffID = values.StaffID,
                StaffFacebook = values.StaffFacebook,
                StaffFullName = values.StaffFullName,
                StaffImageURL = values.StaffImageURL,
                StaffInstagram = values.StaffInstagram,
                StaffLinkedin = values.StaffLinkedin,
                StaffTitle = values.StaffTitle,
                StaffX = values.StaffX,
            };
        }
    }
}
