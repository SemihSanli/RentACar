using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Commands.AboutCommands;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.AboutQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_MediatR_RentACar.UILayer.Controllers
{
    public class AdminAboutController : Controller
    {
        private readonly IMediator _mediator;

        public AdminAboutController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task< IActionResult> Index()
        {
            var values = await _mediator.Send(new GetAboutQuery());
            return View(values);
        }
        [HttpGet]
        public IActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddAbout(CreateAboutCommand createAboutCommand)
        {
            await _mediator.Send(createAboutCommand);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteAbout(int id)
        {
            await _mediator.Send(new RemoveAboutCommand(id));
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateAbout(int id)
        {
            var value = await _mediator.Send(new GetAboutByIdQuery(id));
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutCommand updateAboutCommand)
        {
            await _mediator.Send(updateAboutCommand);
            return RedirectToAction("Index");
        }
    }
}
