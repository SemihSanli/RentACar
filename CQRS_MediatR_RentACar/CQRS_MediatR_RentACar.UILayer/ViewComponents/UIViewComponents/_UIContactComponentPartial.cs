using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.ContactQueries;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.FeatureQueries;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.ContactResults;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.FeatureResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_MediatR_RentACar.UILayer.ViewComponents.UIViewComponents
{
    public class _UIContactComponentPartial:ViewComponent
    {
        private readonly IMediator _mediator;

        public _UIContactComponentPartial(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<GetContactQueryResult> contacts = await _mediator.Send(new GetContactQuery());
            return View(contacts);
        }
    }
}
