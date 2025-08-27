using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.LocationQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_MediatR_RentACar.UILayer.Controllers
{
    public class AdminLocationController : Controller
    {
        private readonly IMediator _mediator;

        public AdminLocationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _mediator.Send(new GetLocationQuery());
            return View(values);
        }
    }
}
