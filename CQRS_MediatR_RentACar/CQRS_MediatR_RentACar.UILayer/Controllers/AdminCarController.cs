using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Commands.CarCommands;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.CarQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_MediatR_RentACar.UILayer.Controllers
{
    public class AdminCarController : Controller
    {
        private readonly IMediator _mediator;

        public AdminCarController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _mediator.Send(new GetCarQuery());
            return View(values);
        }
        [HttpGet]
        public IActionResult AddCar()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCar(CreateCarCommand createCarCommand)
        {
            await _mediator.Send(createCarCommand);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteCar(int id)
        {
            await _mediator.Send(new RemoveCarCommand(id));
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCar(int id)
        {
            var value = await _mediator.Send(new GetCarByIdQuery(id));
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCar(UpdateCarCommand updateCarCommand)
        {
            await _mediator.Send(updateCarCommand);
            return RedirectToAction("Index");
        }
    }
}
