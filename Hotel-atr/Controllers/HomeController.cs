using Hotel_atr.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;
using System.Security.Claims;

namespace Hotel_atr.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private HotelAtrContext _db;

        public HomeController(ILogger<HomeController> logger,
            HotelAtrContext db)
        {
            _logger = logger;
            _db = db;
        }





        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string login, string password) 
        {
            if(login == "admin" && password == "admin")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, login)
                };

                var claimIdentity = new ClaimsIdentity(claims, login);

                HttpContext.SignInAsync
                (CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity));
            }

            return RedirectToAction("Index");
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Index(string culture = "")
        {

            var data = _db.Rooms.ToList();


            GetCultures(culture);


            return View();
        }

        public string GetCultures(string code)
        {
            if (!string.IsNullOrWhiteSpace(code))
            {
                CultureInfo.CurrentCulture = new CultureInfo(code);

                CultureInfo.CurrentUICulture = new CultureInfo(code);
            }
            return "";
        }

        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}