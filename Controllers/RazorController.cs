using Microsoft.AspNetCore.Mvc;

namespace il_mio_primo_blog.Controllers
{
    public class RazorController : Controller
    {
        public IActionResult Snacks()
        {
            return View();
        }
    }
}
