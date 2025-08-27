using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.ContactQueries;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.ContactResults;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.ServiceResults;
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
    public class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQuery, GetContactByIdQueryResult>
    {
        private readonly IContactDal _contactDal;

        public GetContactByIdQueryHandler(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _contactDal.GetByIdAsync(request.ContactID);
            return new GetContactByIdQueryResult
            {
                ContactID = values.ContactID,
                Address = values.Address,
                MailUs = values.MailUs,
                Phone = values.Phone,
                Webside = values.Webside,
            };
        }
    }
}
