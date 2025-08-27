using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.ContactQueries;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.CarResults;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.ContactResults;
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
    public class GetContactQueryHandler : IRequestHandler<GetContactQuery, List<GetContactQueryResult>>
    {
        private readonly IContactDal _contactDal;

        public GetContactQueryHandler(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public async Task<List<GetContactQueryResult>> Handle(GetContactQuery request, CancellationToken cancellationToken)
        {
            var values = await _contactDal.GetListAsync();
            return values.Select(x => new GetContactQueryResult
            {
                Address = x.Address,
                MailUs = x.MailUs,
                ContactID = x.ContactID,
                Phone  = x.Phone,
                Webside = x.Webside,
            }).ToList();
        }
    }
}
