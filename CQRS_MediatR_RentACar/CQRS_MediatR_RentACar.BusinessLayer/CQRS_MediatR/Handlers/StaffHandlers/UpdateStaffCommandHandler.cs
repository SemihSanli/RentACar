using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Commands.StaffCommands;
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
    public class UpdateStaffCommandHandler : IRequestHandler<UpdateStaffCommand>
    {
        private readonly IStaffDal _staffDal;

        public UpdateStaffCommandHandler(IStaffDal staffDal)
        {
            _staffDal = staffDal;
        }

        public  async Task Handle(UpdateStaffCommand request, CancellationToken cancellationToken)
        {
            var values = await _staffDal.GetByIdAsync(request.StaffID);
            values.StaffX = request.StaffX;
            values.StaffFacebook = request.StaffFacebook;
            values.StaffFullName = request.StaffFullName;
            values.StaffLinkedin = request.StaffLinkedin;
            values.StaffInstagram = request.StaffInstagram;
            values.StaffImageURL = request.StaffImageURL;
            values.StaffTitle = request.StaffTitle;
        }
    }
}
