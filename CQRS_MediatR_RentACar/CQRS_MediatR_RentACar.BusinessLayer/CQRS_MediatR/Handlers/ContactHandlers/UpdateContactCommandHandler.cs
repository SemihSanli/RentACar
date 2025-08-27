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
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand>
    {
        private readonly IContactDal _contactDal;

        public UpdateContactCommandHandler(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public async Task Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var values = await _contactDal.GetByIdAsync(request.ContactID);
            values.Phone = request.Phone;
            values.Address = request.Address;
            values.Webside = request.Webside;
        }
    }
}
