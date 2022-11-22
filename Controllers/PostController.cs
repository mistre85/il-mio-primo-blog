
using il_mio_primo_blog.Data;
using il_mio_primo_blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace il_mio_primo_blog.Controllers
{
    public class PostController : Controller
    {

        BlogDbContext db;

        public PostController() : base()
        {
            db = new BlogDbContext(); 
        }

        public IActionResult Index()
        {
            //BlogDbContext db = new BlogDbContext();

            List<Post> listaPost = db.Posts.ToList();

            return View(listaPost);
        }
        public IActionResult Detail(int id)
        {

            //BlogDbContext db = new BlogDbContext();

            Post post = db.Posts.Where(p => p.Id == id).FirstOrDefault();
           
            return View(post);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Post post)
        {
            if (!ModelState.IsValid)
            {
                //return View(post);
                return View();
            }

            db.Posts.Add(post);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
