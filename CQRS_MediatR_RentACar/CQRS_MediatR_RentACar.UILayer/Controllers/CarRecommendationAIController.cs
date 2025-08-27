using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Commands.CarRecommendationAICommands;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.CarRecommendationAIQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_MediatR_RentACar.UILayer.Controllers
{
    public class CarRecommendationAIController : Controller
    {
        private readonly IMediator _mediator;

        public CarRecommendationAIController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> RecommendedCarList()
        {
            var values = await _mediator.Send(new GetCarRecommendationAIQuery());
            return View(values);
        }
        public  IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> Index(string customerPrompt)
        {
            if (string.IsNullOrWhiteSpace(customerPrompt))
            {
                ViewBag.ErrorMessage = "Lütfen Prompt Giriniz";
                ViewBag.IsError = true;
                return View();
            }
            try
            {
                await _mediator.Send(new CreateCarRecommendationAICommand
                {
                    CustomerPrompt = customerPrompt
                });
                ViewBag.SuccessMessage = "Sorunuz Alındı, AI 3 Farklı Cevap Oluşturuyor.. :)";
                ViewBag.IsSuccess = true;
                return RedirectToAction("RecommendedCarList", "CarRecommendationAI");
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = $"AI Servisinde hata:{ex.Message}";
                ViewBag.IsError = true;
                return View();
            }
           
        }
    }
}
