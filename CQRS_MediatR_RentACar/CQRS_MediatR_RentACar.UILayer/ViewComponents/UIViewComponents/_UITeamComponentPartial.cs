using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.FeatureQueries;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.StaffQueries;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.FeatureResults;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.StaffResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_MediatR_RentACar.UILayer.ViewComponents.UIViewComponents
{
    public class _UITeamComponentPartial:ViewComponent
    {
        private readonly IMediator _mediator;

        public _UITeamComponentPartial(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<GetStaffQueryResult> staffs = await _mediator.Send(new GetStaffQuery());
            return View(staffs);

        }
    }
}
