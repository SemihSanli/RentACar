using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.CarQueries;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.CarResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CQRS_MediatR_RentACar.UILayer.ViewComponents.UIViewComponents
{
    public class _UIBookingOptionsComponentPartial:ViewComponent
    {
        private readonly IMediator _mediator;
        public _UIBookingOptionsComponentPartial(IMediator mediator) { _mediator = mediator; }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var allCars = await _mediator.Send(new GetCarsByBrandQuery(null));
            var brands = allCars.Select(c => c.CarBrand).Distinct().ToList();
            ViewBag.Brands = new SelectList(brands);
            return View(new List<GetCarQueryResult>());
        }
    }
}
