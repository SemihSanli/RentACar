using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.CarQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_MediatR_RentACar.UILayer.ViewComponents.AdminDashboardViewComponents
{
    public class _AdminDashboardCustomerStatisticComponentPartial:ViewComponent
    {
        private readonly IMediator _mediator;

        public _AdminDashboardCustomerStatisticComponentPartial(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _mediator.Send(new GetLast4CarQuery());
            return View(values);
        }
    }
}
