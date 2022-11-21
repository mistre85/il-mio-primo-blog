
using il_mio_primo_blog.Data;
using il_mio_primo_blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace il_mio_primo_blog.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            BlogDbContext db = new BlogDbContext();

            List<Post> listaPost = db.Posts.ToList();

            //qualche altra cosa...

            return View(listaPost);
        }
        public IActionResult Detail(int id)
        {

            BlogDbContext db = new BlogDbContext();

            Post post = db.Posts.Where(p => p.Id == id).FirstOrDefault();

            return View(post);
        }
    }
}
