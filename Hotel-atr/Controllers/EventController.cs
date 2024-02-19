using Microsoft.AspNetCore.Mvc;

namespace Hotel_atr.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
