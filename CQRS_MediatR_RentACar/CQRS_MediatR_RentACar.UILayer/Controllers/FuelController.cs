using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.LocationQueries;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.LocationResults;
using CQRS_MediatR_RentACar.UILayer.Models;
using CQRS_MediatR_RentACar.UILayer.RapidApiServices.FuelAPI;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CQRS_MediatR_RentACar.UILayer.Controllers
{
    public class FuelController : Controller
    {
        private readonly IMediator _mediator;
        private readonly FuelRapidApiClient _fuelClient;

        public FuelController(IMediator mediator, FuelRapidApiClient fuelClient)
        {
            _mediator = mediator;
            _fuelClient = fuelClient;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var vm = new FuelCalculatorViewModel();
            await PopulateLocations(vm);
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Index(FuelCalculatorViewModel model)
        {
            await PopulateLocations(model);
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Use manual distance if provided, otherwise calculate from coordinates
            if (model.ManualDistanceKm.HasValue && model.ManualDistanceKm.Value > 0)
            {
                model.DistanceKm = model.ManualDistanceKm.Value;
            }
            else
            {
                var locations = await _mediator.Send(new GetLocationQuery());
                var origin = locations.FirstOrDefault(l => l.LocationID == model.OriginLocationId);
                var dest = locations.FirstOrDefault(l => l.LocationID == model.DestinationLocationId);
                if (origin == null || dest == null)
                {
                    model.Message = "Lokasyonlar bulunamadı.";
                    return View(model);
                }

                if (!double.TryParse(origin.Latitude, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out var oLat) ||
                    !double.TryParse(origin.Longitude, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out var oLng) ||
                    !double.TryParse(dest.Latitude, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out var dLat) ||
                    !double.TryParse(dest.Longitude, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out var dLng))
                {
                    model.Message = "Lokasyon koordinatları geçersiz.";
                    return View(model);
                }

                var distanceKm = CalculateHaversineDistanceKm(oLat, oLng, dLat, dLng);
                model.DistanceKm = Math.Round(distanceKm, 2);
            }

            // Use manual fuel price if provided, otherwise fetch from API
            if (model.ManualFuelPrice.HasValue && model.ManualFuelPrice.Value > 0)
            {
                model.PricePerLiter = model.ManualFuelPrice.Value;
                model.Currency = "TRY";
            }
            else
            {
                var (gasoline, diesel, lpg, currency) = await _fuelClient.GetTurkeyPricesAsync();
                model.Currency = currency ?? "TRY";

                decimal? price = model.FuelType switch
                {
                    "diesel" => diesel,
                    "lpg" => lpg,
                    _ => gasoline
                };
                model.PricePerLiter = price;

                if (price is null)
                {
                    model.Message = "Yakıt fiyatı alınamadı. Lütfen manuel olarak giriniz.";
                    return View(model);
                }
            }

            // Calculate total distance (round trip if selected)
            model.TotalDistanceKm = model.IsRoundTrip ? model.DistanceKm * 2 : model.DistanceKm;

            // Calculate fuel consumption
            var consumption = model.ConsumptionLPer100Km ?? 8.0m;
            var liters = (decimal)model.TotalDistanceKm.GetValueOrDefault() * consumption / 100m;
            model.TotalFuelLiters = Math.Round(liters, 2);

            // Calculate estimated cost
            model.EstimatedCost = Math.Round(model.TotalFuelLiters.Value * model.PricePerLiter.Value, 2);

            // Estimate travel time (assuming 80 km/h average)
            const double avgSpeedKmh = 80.0;
            var timeHours = model.TotalDistanceKm.GetValueOrDefault() / avgSpeedKmh;
            model.EstimatedTimeHours = (int)Math.Ceiling(timeHours);

            return View(model);
        }

        private async Task PopulateLocations(FuelCalculatorViewModel model)
        {
            var list = await _mediator.Send(new GetLocationQuery());
            model.Locations = list
                .OrderBy(x => x.Name)
                .Select(x => new SelectListItem { Value = x.LocationID.ToString(), Text = x.Name })
                .ToList();
        }

        private static double CalculateHaversineDistanceKm(double lat1, double lon1, double lat2, double lon2)
        {
            const double R = 6371.0; // km
            double dLat = DegreesToRadians(lat2 - lat1);
            double dLon = DegreesToRadians(lon2 - lon1);
            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(DegreesToRadians(lat1)) * Math.Cos(DegreesToRadians(lat2)) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return R * c;
        }

        private static double DegreesToRadians(double deg) => deg * Math.PI / 180.0;
    }
}
