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
    public class RemoveStaffCommandHandler : IRequestHandler<RemoveStaffCommand>
    {
        private readonly IStaffDal _staffDal;

        public RemoveStaffCommandHandler(IStaffDal staffDal)
        {
            _staffDal = staffDal;
        }

        public async Task Handle(RemoveStaffCommand request, CancellationToken cancellationToken)
        {
            var values = await _staffDal.GetByIdAsync(request.StaffID);
            await _staffDal.DeleteAsync(values);
        }
    }
}
