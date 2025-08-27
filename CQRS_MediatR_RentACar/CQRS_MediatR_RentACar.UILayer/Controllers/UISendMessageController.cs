using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Commands.SendMessageCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_MediatR_RentACar.UILayer.Controllers
{
    public class UISendMessageController : Controller
    {
        private readonly IMediator _mediator;

        public UISendMessageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateSendMessageCommand command)
        {
            await _mediator.Send(command);
            TempData["ContactSuccess"] = "Mesajınız alındı.";
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
