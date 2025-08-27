using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.AboutQueries;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.AboutResults;
using CQRS_MediatR_RentACar.DataAccessLayer.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Handlers.AboutHandlers
{
    public class GetAboutQueryHandler : IRequestHandler<GetAboutQuery, List<GetAboutQueryResult>>
    {
        private readonly IAboutDal _aboutDal;

        public GetAboutQueryHandler(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public async Task<List<GetAboutQueryResult>> Handle(GetAboutQuery request, CancellationToken cancellationToken)
        {
            var values = await _aboutDal.GetListAsync();
            return values.Select(x => new GetAboutQueryResult
            {
                AboutID = x.AboutID,
                AboutArticle1 = x.AboutArticle1,
                AboutArticle2 = x.AboutArticle2,
                AboutArticle3 = x.AboutArticle3,
                AboutBigImageURL = x.AboutBigImageURL,
                AboutCeoFullName = x.AboutCeoFullName,
                AboutCeoImageURL = x.AboutCeoImageURL,
                AboutCeoTitle = x.AboutCeoTitle,
                AboutDescription = x.AboutDescription,
                AboutIconURL = x.AboutIconURL,
                AboutLayerDescription = x.AboutLayerDescription,
                AboutLayerTitle = x.AboutLayerTitle,
                AboutSubDescription = x.AboutSubDescription
            }).ToList();
        }
    }
}
