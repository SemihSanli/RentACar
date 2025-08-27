using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.CarQueries;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.LocationQueries;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.ServiceQueries;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.TestimonialQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_MediatR_RentACar.UILayer.ViewComponents.UIViewComponents
{
    public class _UIFactComponentPartial:ViewComponent
    {
        private readonly IMediator _mediator;

        public _UIFactComponentPartial(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task< IViewComponentResult> InvokeAsync()
        {
            var result = await _mediator.Send(new GetTestimonialCountQuery());
            ViewBag.TestimonialCount = result.Count;
            var result2 = await _mediator.Send(new GetCarCountQuery());
            ViewBag.CarCount = result2.Count;
            var result3 = await _mediator.Send(new GetLocationCountQuery());
            ViewBag.LocationCount = result3.Count;
            var result4 = await _mediator.Send(new GetServiceCountQuery());
            ViewBag.ServiceCount = result4.Count;
            return View();
        }
    }
}
