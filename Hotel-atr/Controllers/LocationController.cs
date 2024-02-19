using Microsoft.AspNetCore.Mvc;

namespace Hotel_atr.Controllers
{
    public class LocationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
