using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Hotel_atr.Models;

namespace Hotel_atr.Controllers
{
    public class RoomController : Controller
    {
        private IWebHostEnvironment host;

        public RoomController(IWebHostEnvironment host)
        {
            this.host = host;
        }

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


        //string email, name
        //User user
        //Request.Form
        [HttpPost]
        public IActionResult Subcribes(IFormFile userFile)
        {
            string path = Path.Combine(host.WebRootPath, 
                "files", 
                userFile.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                userFile.CopyTo(stream);
            }

            return View();
        }



    }
}
