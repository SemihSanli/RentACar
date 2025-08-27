using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Commands.BookingCommands;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.AirportQueries;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.CarQueries;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.CarResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CQRS_MediatR_RentACar.UILayer.Controllers
{
    public class BrowseCarController : Controller
    {
        private readonly IMediator _mediator;

        public BrowseCarController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // Tüm araç markalarını al
            var allCars = await _mediator.Send(new GetCarsByBrandQuery(null));
            var brands = allCars.Select(c => c.CarBrand).Distinct().ToList();

            //Havaalanlarını da burda aldım
            var airports = await _mediator.Send(new GetAirportQuery());
            ViewBag.Airports = new SelectList(airports,"AirportID","Name");

            ViewBag.Brands = new SelectList(brands); // Dropdown
            return View(new List<GetCarQueryResult>()); // boş liste
        }

        [HttpPost]
        public async Task<IActionResult> Index(string selectedBrand,int? selectedAirportID)
        {
            // Seçilen marka ile araçları getir
            var cars = await _mediator.Send(new GetCarsByBrandQuery(selectedBrand));

            // Dropdown için tekrar markaları oluştur
            var allCars = await _mediator.Send(new GetCarsByBrandQuery(null));
            var brands = allCars.Select(c => c.CarBrand).Distinct().ToList();
            ViewBag.Brands = new SelectList(brands, selectedBrand);

            ViewBag.SelectedBrand = selectedBrand;

            var airports = await _mediator.Send(new GetAirportQuery());
            ViewBag.Airports = new SelectList(airports, "AirportID", "Name");

            return View(cars); // Listeyi View’e gönder
        }

        public async Task<IActionResult> Book(int carId, DateTime pickUpDate, DateTime dropOffDate, string selectedBrand)
        {
            if (pickUpDate >= dropOffDate)
            {
                TempData["BookingError"] = "Teslimat tarihi alış tarihinden küçük olamaz";
                return RedirectToAction("Index", new { selectedBrand });
            }

            await _mediator.Send(new CreateBookingCommand
            {
                CarID = carId,
                PickUpDate = pickUpDate,
                DropOffDate = dropOffDate
            });

            TempData["BookingSuccess"] = "Rezervasyon Oluşturuldu";
            return RedirectToAction("Index", "MainPage");
        }
    }
}
