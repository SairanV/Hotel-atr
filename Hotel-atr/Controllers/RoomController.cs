using Microsoft.AspNetCore.Mvc;

namespace Hotel_atr.Controllers
{
    public class RoomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RoomList()
        {
            return View();  
        }

        public IActionResult RoomDetails()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Subcribes(string email)
        {
            return View();
        }
    }
}
