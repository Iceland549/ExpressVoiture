using ExpressVoiture.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ExpressVoiture.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Voitures");
            }
            return Redirect("/Identity/Account/Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("/Home/Error/{statusCode:int?}")]

        public IActionResult Error(int? statusCode)
        {
            if (statusCode == 404)
            {
                return View("Error");
            }

            return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
