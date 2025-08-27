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
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand>
    {
        private readonly IServiceDal _serviceDal;

        public UpdateServiceCommandHandler(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }

        public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var values = await _serviceDal.GetByIdAsync(request.ServiceID);
            values.ServiceIconURL = request.ServiceIconURL;
            values.ServiceArticleDescription = request.ServiceArticleDescription;
            values.ServiceEntryTitle = request.ServiceEntryTitle;
            values.ServiceArticleTitle = request.ServiceArticleTitle;
        }
    }
}
