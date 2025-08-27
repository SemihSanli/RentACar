using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Commands.ContactCommands;
using CQRS_MediatR_RentACar.DataAccessLayer.Abstract;
using CQRS_MediatR_RentACar.DataAccessLayer.EntityFramework;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Handlers.ContactHandlers
{
    public class RemoveContactCommandHandler : IRequestHandler<RemoveContactCommand>
    {
        private readonly IContactDal _contactDal;

        public RemoveContactCommandHandler(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public async Task Handle(RemoveContactCommand request, CancellationToken cancellationToken)
        {
            var values = await _contactDal.GetByIdAsync(request.ContactID);
            await _contactDal.DeleteAsync(values);
        }
    }
}
