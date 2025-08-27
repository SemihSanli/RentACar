using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Commands.ContactCommands;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.ContactQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_MediatR_RentACar.UILayer.Controllers
{
    public class AdminContactController : Controller
    {
        private readonly IMediator _mediator;

        public AdminContactController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _mediator.Send(new GetContactQuery());
            return View(values);
        }

        [HttpGet]
        public IActionResult AddContact()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddContact(CreateContactCommand createContactCommand)
        {
            await _mediator.Send(createContactCommand);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteContact(int id)
        {
            await _mediator.Send(new RemoveContactCommand(id));
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateContact(int id)
        {
            var value = await _mediator.Send(new GetContactByIdQuery(id));
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateContact(UpdateContactCommand updateContactCommand)
        {
            await _mediator.Send(updateContactCommand);
            return RedirectToAction("Index");
        }
    }
}
