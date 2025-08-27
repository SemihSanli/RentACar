using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.AboutQueries;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.AboutResults;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.StaffResults;
using CQRS_MediatR_RentACar.DataAccessLayer.Abstract;
using CQRS_MediatR_RentACar.DataAccessLayer.EntityFramework;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Handlers.AboutHandlers
{
    public class GetAboutByIdQueryHandler : IRequestHandler<GetAboutByIdQuery, GetAboutByIdQueryResult>
    {
        private readonly IAboutDal _aboutDal;

        public GetAboutByIdQueryHandler(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _aboutDal.GetByIdAsync(request.AboutID);
            return new GetAboutByIdQueryResult
            {
                AboutID = values.AboutID,
                AboutArticle1 = values.AboutArticle1,
                AboutArticle2 = values.AboutArticle2,
                AboutArticle3 = values.AboutArticle3,
                AboutBigImageURL = values.AboutBigImageURL,
                AboutCeoFullName = values.AboutCeoFullName,
                AboutCeoImageURL = values.AboutCeoImageURL,
                AboutCeoTitle = values.AboutCeoTitle,
                AboutDescription = values.AboutDescription,
                AboutIconURL = values.AboutIconURL,
                AboutLayerDescription = values.AboutLayerDescription,
                AboutLayerTitle = values.AboutLayerTitle,
                AboutSubDescription = values.AboutSubDescription,
            };
        }
    }
}
