using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Commands.TestimonialCommands;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.TestimonialQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_MediatR_RentACar.UILayer.Controllers
{
    public class AdminTestimonialController : Controller
    {
        private readonly IMediator _mediator;

        public AdminTestimonialController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _mediator.Send(new GetTestimonialQuery());
            return View(values);
        }
        [HttpGet]
        public IActionResult AddTestimonial()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddTestimonial(CreateTestimonialCommand createTestimonialCommand)
        {
            await _mediator.Send(createTestimonialCommand);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            await _mediator.Send(new RemoveTestimonialCommand(id));
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var value = await _mediator.Send(new GetTestimonialByIdQuery(id));
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialCommand updateTestimonialCommand)
        {
            await _mediator.Send(updateTestimonialCommand);
            return RedirectToAction("Index");
        }
    }
}
