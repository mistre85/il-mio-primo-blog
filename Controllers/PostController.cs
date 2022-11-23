
using il_mio_primo_blog.Data;
using il_mio_primo_blog.Models;
using il_mio_primo_blog.Models.Form;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

            List<Post> listaPost = db.Posts.Include(post => post.Category).ToList();

            return View(listaPost);
        }
        public IActionResult Detail(int id)
        {

            //BlogDbContext db = new BlogDbContext();

            Post post = db.Posts.Where(p => p.Id == id).Include("Category").FirstOrDefault();

            return View(post);
        }

        public IActionResult Create()
        {
            PostForm formData = new PostForm();

            formData.Post = new Post();
            formData.Categories = db.Categories.ToList();

            return View(formData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PostForm formData)
        {
            if (!ModelState.IsValid)
            {
                //return View(postItem);
                //PostForm postItem = new PostForm();
                //postItem.Post = postItem;
                formData.Categories = db.Categories.ToList();
                return View(formData);
            }

            db.Posts.Add(formData.Post);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            
            Post post = db.Posts.Where(post => post.Id == id).FirstOrDefault();

            if (post == null)
                return NotFound();

            PostForm formData = new PostForm();

            formData.Post = post;
            formData.Categories = db.Categories.ToList();

            //return View() --> non funziona perchè non ha la memoria della postItem
            return View(formData);
        }

        //[HttpPost]
        //public IActionResult Update(Post postItem)
        //{

        //    if (!ModelState.IsValid)
        //    {
        //        //return View(postItem);
        //        return View();
        //    }

        //    db.Posts.Update(postItem);
        //    db.SaveChanges();

        //    return RedirectToAction("Index");
        //}

        //altro modo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, PostForm formData)
        {

            if (!ModelState.IsValid)
            {
                //return View(postItem);
                formData.Categories = db.Categories.ToList();
                return View(formData);
            }

            /*update esplicito con nuovo oggetto
            Post postItem = db.Posts.Where(post => post.Id == id).FirstOrDefault();

            if (postItem == null)
            {
                return NotFound();
            }

            postItem.Title = formData.Post.Title;
            postItem.Description = formData.Post.Description;
            postItem.Image = formData.Post.Image;
            postItem.CategoryId = formData.Post.CategoryId;
            */

            //update implicito
            formData.Post.Id = id;
            db.Posts.Update(formData.Post);
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
