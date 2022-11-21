using il_mio_primo_blog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace il_mio_primo_blog.Controllers
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
            ViewData["title"] = "Home";
            return View();
        }

        public IActionResult About()
        {
            ViewData["title"] = "About";
            return View();
        }

        public IActionResult Privacy()
        {
            ViewData["title"] = "Privacy";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}