using Microsoft.AspNetCore.Mvc;

namespace CQRS_MediatR_RentACar.UILayer.Controllers
{
    public class AdminDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
