using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Commands.SliderCommands;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.SliderQueries;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.SliderQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_MediatR_RentACar.UILayer.Controllers
{
    public class AdminSliderController : Controller
    {
        private readonly IMediator _mediator;

        public AdminSliderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _mediator.Send(new GetSliderQuery());
            return View(values);
        }
        [HttpGet]
        public IActionResult AddSlider()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddSlider(CreateSliderCommand createSliderCommand)
        {
            await _mediator.Send(createSliderCommand);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteSlider(int id)
        {
            await _mediator.Send(new RemoveSliderCommand(id));
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateSlider(int id)
        {
            var value = await _mediator.Send(new GetSliderByIdQuery(id));
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSlider(UpdateSliderCommand updateSliderCommand)
        {
            await _mediator.Send(updateSliderCommand);
            return RedirectToAction("Index");
        }
    }
}
