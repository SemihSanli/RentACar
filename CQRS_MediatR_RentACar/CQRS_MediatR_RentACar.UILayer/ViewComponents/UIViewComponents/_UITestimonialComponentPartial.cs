using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.FeatureQueries;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.TestimonialQueries;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.FeatureResults;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.TestimonialResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_MediatR_RentACar.UILayer.ViewComponents.UIViewComponents
{
    public class _UITestimonialComponentPartial:ViewComponent
    {
        private readonly IMediator _mediator;

        public _UITestimonialComponentPartial(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<GetTestimonialQueryResult> testimonials = await _mediator.Send(new GetTestimonialQuery());
            return View(testimonials);
        }
    }
}
