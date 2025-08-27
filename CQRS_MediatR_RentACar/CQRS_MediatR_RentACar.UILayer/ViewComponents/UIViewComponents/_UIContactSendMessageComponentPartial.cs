using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_MediatR_RentACar.UILayer.ViewComponents.UIViewComponents
{
    public class _UIContactSendMessageComponentPartial:ViewComponent
    {

        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}
