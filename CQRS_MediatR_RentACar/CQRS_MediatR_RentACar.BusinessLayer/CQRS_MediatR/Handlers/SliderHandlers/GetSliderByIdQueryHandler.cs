using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.SliderQueries;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.SliderResults;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.StaffResults;
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
    public class GetSliderByIdQueryHandler : IRequestHandler<GetSliderByIdQuery, GetSliderByIdQueryResult>
    {
        private readonly ISliderDal _sliderDal;

        public GetSliderByIdQueryHandler(ISliderDal sliderDal)
        {
            _sliderDal = sliderDal;
        }

        public async Task<GetSliderByIdQueryResult> Handle(GetSliderByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _sliderDal.GetByIdAsync(request.SliderID);
            return new GetSliderByIdQueryResult
            {
                SliderID = values.SliderID,
                SliderSubTitle = values.SliderSubTitle,
                SliderTitle = values.SliderTitle,
            };
        }
    }
}
