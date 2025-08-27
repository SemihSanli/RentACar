using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Commands.StaffCommands;
using CQRS_MediatR_RentACar.DataAccessLayer.Abstract;
using CQRS_MediatR_RentACar.DataAccessLayer.EntityFramework;
using CQRS_MediatR_RentACar.EntityLayer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Handlers.StaffHandlers
{
    public class CreateStaffCommandHandler : IRequestHandler<CreateStaffCommand>
    {
        private readonly IStaffDal _staffDal;

        public CreateStaffCommandHandler(IStaffDal staffDal)
        {
            _staffDal = staffDal;
        }

        public async Task Handle(CreateStaffCommand request, CancellationToken cancellationToken)
        {
            await _staffDal.InsertAsync(new Staff
            {
                StaffFacebook = request.StaffFacebook,
                StaffFullName = request.StaffFullName,
                StaffImageURL = request.StaffImageURL,
                StaffInstagram  = request.StaffInstagram,
                StaffLinkedin = request.StaffLinkedin,
                StaffTitle = request.StaffTitle,
                StaffX  = request.StaffX
            });
        }
    }
}
