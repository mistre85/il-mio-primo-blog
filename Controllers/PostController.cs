
using il_mio_primo_blog.Data;
using il_mio_primo_blog.Models;
using il_mio_primo_blog.Models.Form;
using il_mio_primo_blog.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Diagnostics;

namespace il_mio_primo_blog.Controllers
{
    public class PostController : Controller
    {

        BlogDbContext db;

        IPostRepository postRepository;

        public PostController(IPostRepository _postRepository) : base()
        {
            //da togliere
            db = new BlogDbContext();

            postRepository = _postRepository;
        }

        public IActionResult Index()
        {
            //BlogDbContext db = new BlogDbContext();

            List<Post> listaPost = postRepository.All();

            return View(listaPost);
        }
        public IActionResult Detail(int id)
        {

            //BlogDbContext db = new BlogDbContext();

            Post post = postRepository.GetById(id);

            if(post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        public IActionResult Create()
        {
            PostForm formData = new PostForm();

            formData.Post = new Post();
            formData.Categories = db.Categories.ToList();
            formData.Tags = new List<SelectListItem>();

            List<Tag> tagList = db.Tags.ToList();
            
            foreach(Tag tag in tagList)
            {
                formData.Tags.Add(new SelectListItem(tag.Title,tag.Id.ToString()));
            }

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
                //formData.Tags = db.Tags.ToList();
                formData.Tags = new List<SelectListItem>();

                List<Tag> tagList = db.Tags.ToList();
                

                foreach (Tag tag in tagList)
                {
                    formData.Tags.Add(new SelectListItem(tag.Title, tag.Id.ToString()));
                }

                return View(formData);
            }

            postRepository.Create(formData.Post,formData.SelectedTags);

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {

            Post post = postRepository.GetById(id);

            if (post == null)
                return NotFound();

            PostForm formData = new PostForm();

            formData.Post = post;
            formData.Categories = db.Categories.ToList();
            formData.Tags = new List<SelectListItem>();

            List<Tag> tagsList = db.Tags.ToList();

            foreach (Tag tag in tagsList)
            {
                formData.Tags.Add(new SelectListItem(
                    tag.Title,
                    tag.Id.ToString(),
                    post.Tags.Any(t => t.Id == tag.Id)
                   ));
            }

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
            //da mettere qui per evitare problemi con update nello scenario seguente
            //1. dati invalidi
            //2. dati validi
           

            if (!ModelState.IsValid)
            {
                formData.Post.Id = id;
                //return View(postItem);
                formData.Categories = db.Categories.ToList();
                formData.Tags = new List<SelectListItem>();

                List<Tag> tagList = db.Tags.ToList();

                foreach (Tag tag in tagList)
                {
                    formData.Tags.Add(new SelectListItem(tag.Title, tag.Id.ToString()));
                }

                return View(formData);
            }

            //update esplicito con nuovo oggetto
            Post postItem = postRepository.GetById(id);

            if (postItem == null)
            {
                return NotFound();
            }

            postRepository.Update(postItem, formData.Post, formData.SelectedTags);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            Post post = postRepository.GetById(id);

            if (post == null)
            {
                return NotFound();
            }

            postRepository.Delete(post);


            return RedirectToAction("Index");
        }
    }
}
