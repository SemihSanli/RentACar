using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Commands.ServiceCommands;
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
    public class RemoveServiceCommandHandler : IRequestHandler<RemoveServiceCommand>
    {
        private readonly IServiceDal _serviceDal;

        public RemoveServiceCommandHandler(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }

        public async Task Handle(RemoveServiceCommand request, CancellationToken cancellationToken)
        {
            var values = await _serviceDal.GetByIdAsync(request.ServiceID);
            await _serviceDal.DeleteAsync(values);
        }
    }
}
