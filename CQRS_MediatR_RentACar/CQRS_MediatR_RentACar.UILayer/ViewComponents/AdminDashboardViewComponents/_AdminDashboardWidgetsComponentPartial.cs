using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.CarQueries;
using CQRS_MediatR_RentACar.UILayer.RapidApiServices.FuelAPI;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_MediatR_RentACar.UILayer.ViewComponents.AdminDashboardViewComponents
{
    public class _AdminDashboardWidgetsComponentPartial:ViewComponent
    {
        private readonly FuelRapidApiClient _fuelClient;
        private readonly IMediator _mediator;
        public _AdminDashboardWidgetsComponentPartial(FuelRapidApiClient fuelClient, IMediator mediator)
        {
            _fuelClient = fuelClient;
            _mediator = mediator;
        }

        public  async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await _fuelClient.GetTurkeyPricesAsync(); // API’den euro fiyatı al

            decimal? gasoline = response.gasoline;
            decimal? diesel = response.diesel;
            decimal? lpg = response.lpg;

            //// Eğer API EUR veriyorsa, güncel kurla TL’ye çevir
            decimal euroToTl = 52.0m / 1.0m; // Örnek: 1 EUR = 52 TL (bunu manuel veya başka API’den alabilirsin)

            // TL cinsine çevir ve formatla
            ViewBag.Gasoline =  gasoline.HasValue ? (gasoline.Value * euroToTl).ToString("0.00") : "Veri yok";
            ViewBag.Diesel =  diesel.HasValue ? (diesel.Value * euroToTl).ToString("0.00") : "Veri yok";
            ViewBag.Lpg =  lpg.HasValue ? (lpg.Value * euroToTl).ToString("0.00") : "Veri yok";
            var result2 = await _mediator.Send(new GetCarCountQuery());
            ViewBag.CarCount = result2.Count;
            return View();
        }
    }
  


}

