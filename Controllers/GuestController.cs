using il_mio_primo_blog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace il_mio_primo_blog.Controllers
{
    public class GuestController : Controller
    {
        public IActionResult Index()
        {
            ViewData["title"] = "Home";
            return View();
        }


        public IActionResult Details(int id)
        {
            ViewData["title"] = "Dettaglio Post";
            return View(id);
        }

        public IActionResult Contact()
        {
            ViewData["title"] = "Contattaci";
            return View();
        }

    }
}