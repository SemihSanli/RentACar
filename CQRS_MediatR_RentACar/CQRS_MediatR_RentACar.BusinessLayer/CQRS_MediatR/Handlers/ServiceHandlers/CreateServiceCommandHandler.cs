using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Commands.ServiceCommands;
using CQRS_MediatR_RentACar.DataAccessLayer.Abstract;
using CQRS_MediatR_RentACar.DataAccessLayer.EntityFramework;
using CQRS_MediatR_RentACar.EntityLayer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Handlers.ServiceHandlers
{
    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand>
    {
        private readonly IServiceDal _serviceDal;

        public CreateServiceCommandHandler(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }

        public async Task Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            await _serviceDal.InsertAsync(new Service
            {
                ServiceArticleDescription = request.ServiceArticleDescription,
                ServiceArticleTitle = request.ServiceArticleTitle,
                ServiceEntryTitle = request.ServiceEntryTitle,
                ServiceIconURL = request.ServiceIconURL
            });
        }
    }
}
