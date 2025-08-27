using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Commands.AirportCommands;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.AirportQueries;
using CQRS_MediatR_RentACar.EntityLayer;
using CQRS_MediatR_RentACar.UILayer.DTOs.AirportDTOs;
using CQRS_MediatR_RentACar.UILayer.RapidApiServices.AirportAPI;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace CQRS_MediatR_RentACar.UILayer.Controllers
{
    public class AirportController : Controller
    {

        private readonly IMediator _mediator;
        private readonly AirportRapidApiClient _client; 

        public AirportController(IMediator mediator, AirportRapidApiClient client)
        {
            _mediator = mediator;
            _client = client;
        }

        [HttpPost]
        public async Task<IActionResult> ImportFromRapid()
        {
            // RapidAPI'den veriyi al
            var root = await _client.GetAirportsAsync(); 
            if (root?.data == null || root.data.Length == 0)
            {
                TempData["msg"] = "Kayıt bulunamadı.";
                return RedirectToAction("Index");
            }

            var inserted = 0;
            foreach (var d in root.data)
            {
                var cmd = new CreateAirportCommand
                {
                    Name = d.name,
                    Iata = d.iata,
                    Icao = d.icao,
                    Latitude = d.latitude,     
                    Longitude = d.longitude,   
                    Elevation = d.elevation,   
                    Utc_offset = d.utc_offset, 
                    Dst = d.dst,
                    Timezone = d.timezone
                };
                await _mediator.Send(cmd);
                inserted++;
            }

            TempData["msg"] = $"{inserted} havaalanı kaydedildi.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Message = TempData["msg"];
            return View();
        }
        public async Task<IActionResult> AirportList()
        {
            var values = await _mediator.Send(new GetAirportQuery());
            return View(values);
        }
    }
    
}
