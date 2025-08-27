using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.BookingQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_MediatR_RentACar.UILayer.ViewComponents.AdminDashboardViewComponents
{
    public class _AdminDashboardChartComponentPartial:ViewComponent
    {
        private readonly IMediator _mediator;

        public _AdminDashboardChartComponentPartial(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _mediator.Send(new GetLast5BookingWithCarNameQuery());
            return View(values);
        }
    }
}
