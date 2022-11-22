
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
        public IActionResult Details(int id)
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

        public IActionResult Update(int id)
        {
            Post post = db.Posts.Where(post => post.Id == id).FirstOrDefault();

            if (post == null)
                return NotFound();

            //return View() --> non funziona perchè non ha la memoria della post
            return View(post);
        }

        //[HttpPost]
        //public IActionResult Update(Post post)
        //{

        //    if (!ModelState.IsValid)
        //    {
        //        //return View(post);
        //        return View();
        //    }

        //    db.Posts.Update(post);
        //    db.SaveChanges();

        //    return RedirectToAction("Index");
        //}

        //altro modo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Post formData)
        {

            if (!ModelState.IsValid)
            {
                //return View(post);
                return View();
            }

            Post post = db.Posts.Where(post => post.Id == id).FirstOrDefault();

            if (post == null)
            {
                return NotFound();
            }

            post.Title = formData.Title;
            post.Description = formData.Description;
            post.Image = formData.Image;

            //db.Posts.Update(post);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            Post post = db.Posts.Where(post => post.Id == id).FirstOrDefault();

            if (post == null)
            {
                return NotFound();
            }

            db.Posts.Remove(post);
            db.SaveChanges();


            return RedirectToAction("Index");
        }
    }
}
