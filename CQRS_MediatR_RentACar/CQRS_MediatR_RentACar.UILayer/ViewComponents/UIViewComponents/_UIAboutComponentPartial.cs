using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.AboutQueries;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.AboutResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_MediatR_RentACar.UILayer.ViewComponents.UIViewComponents
{
    public class _UIAboutComponentPartial:ViewComponent
    {
        private readonly IMediator _mediator;

        public _UIAboutComponentPartial(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task< IViewComponentResult> InvokeAsync()
        {
            List<GetAboutQueryResult> abouts = await _mediator.Send(new GetAboutQuery());
            return View(abouts);
        }
    }
}
