using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.CarQueries;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.CarResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_MediatR_RentACar.UILayer.ViewComponents.UIViewComponents
{
    public class _UICarCategoryComponentPartial:ViewComponent
    {
        private readonly IMediator _mediator;

        public _UICarCategoryComponentPartial(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<GetCarQueryResult> cars = await _mediator.Send(new GetCarQuery());
            return View(cars);
        }
    }
}
