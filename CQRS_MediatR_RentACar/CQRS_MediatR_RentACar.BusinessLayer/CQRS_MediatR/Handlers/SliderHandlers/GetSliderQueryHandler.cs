using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.SliderQueries;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.ServiceResults;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.SliderResults;
using CQRS_MediatR_RentACar.DataAccessLayer.Abstract;
using CQRS_MediatR_RentACar.DataAccessLayer.EntityFramework;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Handlers.SliderHandlers
{
    public class GetSliderQueryHandler : IRequestHandler<GetSliderQuery, List<GetSliderQueryResult>>
    {
        private readonly ISliderDal _sliderDal;

        public GetSliderQueryHandler(ISliderDal sliderDal)
        {
            _sliderDal = sliderDal;
        }

        public async Task<List<GetSliderQueryResult>> Handle(GetSliderQuery request, CancellationToken cancellationToken)
        {
            var values = await _sliderDal.GetListAsync();
            return values.Select(x => new GetSliderQueryResult
            {
                SliderTitle = x.SliderTitle,
                SliderSubTitle = x.SliderSubTitle,
                SliderID = x.SliderID
            }).ToList();
        }
    }
}
