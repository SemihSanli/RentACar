using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Commands.LocationCommands;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.LocationQueries;
using CQRS_MediatR_RentACar.UILayer.RapidApiServices.CityAPI;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_MediatR_RentACar.UILayer.Controllers
{
    public class LocationController : Controller
    {
        private readonly IMediator _mediator;
        private readonly LocationRapidApiClient _client;

        public LocationController(LocationRapidApiClient client, IMediator mediator)
        {
            _client = client;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> ImportFromRapid()
        {
            // RapidAPI'den Türkiye şehirlerini al
            var cities = await _client.GetCitiesAsync("tr");
            if (cities == null || cities.Count == 0)
            {
                TempData["msg"] = "Şehir verisi bulunamadı.";
                return RedirectToAction("Index");
            }

            var inserted = 0;
            foreach (var c in cities)
            {
                var cmd = new CreateLocationCommand
                {
                    Name = c.name,
                    StateCode = c.stateCode,
                    CountryCode = c.countryCode,
                    Latitude = c.latitude,
                    Longitude = c.longitude
                };
                await _mediator.Send(cmd);
                inserted++;
            }

            TempData["msg"] = $"{inserted} şehir kaydedildi.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Message = TempData["msg"];
            return View();
        }

        public async Task<IActionResult> CityList()
        {
            var values = await _mediator.Send(new GetLocationQuery());
            return View(values);
        }
    }
}
