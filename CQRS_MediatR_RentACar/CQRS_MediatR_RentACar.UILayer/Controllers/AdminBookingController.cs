using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.BookingQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_MediatR_RentACar.UILayer.Controllers
{
    public class AdminBookingController : Controller
    {
        private readonly IMediator _mediator;

        public AdminBookingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _mediator.Send(new GetBookingWithCarNameQuery());
            return View(values);
        }
    }
}
