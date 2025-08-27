using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.SliderQueries;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.SliderResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_MediatR_RentACar.UILayer.ViewComponents.UIViewComponents
{
    public class _UICarouselComponentPartial:ViewComponent
    {
        private readonly IMediator _mediator;

        public _UICarouselComponentPartial(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task< IViewComponentResult> InvokeAsync()
        {
            List<GetSliderQueryResult> sliders = await _mediator.Send(new GetSliderQuery());
            return View(sliders);
        }
    }
}
