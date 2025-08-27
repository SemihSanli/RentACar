using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Commands.ContactCommands;
using CQRS_MediatR_RentACar.DataAccessLayer.Abstract;
using CQRS_MediatR_RentACar.DataAccessLayer.EntityFramework;
using CQRS_MediatR_RentACar.EntityLayer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Handlers.ContactHandlers
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand>
    {
        private readonly IContactDal _contactDal;

        public CreateContactCommandHandler(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public async Task Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            await _contactDal.InsertAsync(new Contact
            {
                Address = request.Address,
                MailUs = request.MailUs,
                Phone = request.Phone,
                Webside = request.Webside,
            });
        }
    }
}
