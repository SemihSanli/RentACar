using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.FeatureQueries;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.FeatureResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_MediatR_RentACar.UILayer.ViewComponents.UIViewComponents
{
    public class _UIFeatureComponentPartial:ViewComponent
    {
        private readonly IMediator _mediator;

        public _UIFeatureComponentPartial(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<GetFeatureQueryResult> features = await _mediator.Send(new GetFeatureQuery());
            return View(features);
        }
    }
}
