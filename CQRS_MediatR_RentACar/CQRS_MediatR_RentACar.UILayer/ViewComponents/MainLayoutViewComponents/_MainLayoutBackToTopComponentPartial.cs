using Microsoft.AspNetCore.Mvc;

namespace CQRS_MediatR_RentACar.UILayer.ViewComponents.MainLayoutViewComponents
{
    public class _MainLayoutBackToTopComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
