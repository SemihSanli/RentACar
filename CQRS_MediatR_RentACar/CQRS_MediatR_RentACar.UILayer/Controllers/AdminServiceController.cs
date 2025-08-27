using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Commands.ServiceCommands;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.ServiceQueries;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.ServiceQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_MediatR_RentACar.UILayer.Controllers
{
    public class AdminServiceController : Controller
    {
        private readonly IMediator _mediator;

        public AdminServiceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _mediator.Send(new GetServiceQuery());
            return View(values);
        }
        [HttpGet]
        public IActionResult AddService()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddService(CreateServiceCommand createServiceCommand)
        {
            await _mediator.Send(createServiceCommand);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteService(int id)
        {
            await _mediator.Send(new RemoveServiceCommand(id));
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateService(int id)
        {
            var value = await _mediator.Send(new GetServiceByIdQuery(id));
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateService(UpdateServiceCommand updateServiceCommand)
        {
            await _mediator.Send(updateServiceCommand);
            return RedirectToAction("Index");
        }
    }
}
