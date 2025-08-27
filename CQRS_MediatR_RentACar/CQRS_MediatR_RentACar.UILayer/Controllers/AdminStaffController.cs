using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Commands.StaffCommands;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.StaffQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_MediatR_RentACar.UILayer.Controllers
{
    public class AdminStaffController : Controller
    {
        private readonly IMediator _mediator;

        public AdminStaffController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task< IActionResult> Index()
        {
            var values = await _mediator.Send(new GetStaffQuery());
            return View(values);
        }
        [HttpGet]
        public IActionResult AddStaff()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddStaff(CreateStaffCommand createStaffCommand)
        {
            await _mediator.Send(createStaffCommand);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteStaff(int id)
        {
            await _mediator.Send(new RemoveStaffCommand(id));
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateStaff(int id)
        {
            var value = await _mediator.Send(new GetStaffByIdQuery(id));
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateStaff(UpdateStaffCommand updateStaffCommand)
        {
            await _mediator.Send(updateStaffCommand);
            return RedirectToAction("Index");
        }
    }
}
