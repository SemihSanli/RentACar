using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.StaffQueries;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.SliderResults;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.StaffResults;
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
    public class GetStaffQueryHandler : IRequestHandler<GetStaffQuery, List<GetStaffQueryResult>>
    {
        private readonly IStaffDal _staffDal;

        public GetStaffQueryHandler(IStaffDal staffDal)
        {
            _staffDal = staffDal;
        }

        public async Task<List<GetStaffQueryResult>> Handle(GetStaffQuery request, CancellationToken cancellationToken)
        {
            var values = await _staffDal.GetListAsync();
            return values.Select(x => new GetStaffQueryResult
            {
                StaffX = x.StaffX,
                StaffTitle = x.StaffTitle,
                StaffLinkedin = x.StaffLinkedin,
                StaffInstagram = x.StaffInstagram,
                StaffFacebook = x.StaffFacebook,
                StaffFullName = x.StaffFullName,
                StaffID = x.StaffID,
                StaffImageURL = x.StaffImageURL
            }).ToList();
        }
    }
}
