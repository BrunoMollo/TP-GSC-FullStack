using Microsoft.AspNetCore.Mvc;

namespace TP_GSC_BackEnd.Controllers.MVC
{
    public class ThingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List() 
        {
            return View();
        }

    }
}
