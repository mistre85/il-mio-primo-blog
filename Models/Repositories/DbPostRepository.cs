using il_mio_primo_blog.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;

namespace il_mio_primo_blog.Models.Repositories
{
    public class DbPostRepository : IPostRepository
    {
        private BlogDbContext db;

        public DbPostRepository()
        {
            db = new BlogDbContext();
        }

        public List<Post> All()
        {
            return AllWithRelations();
        }

        public List<Post> AllWithRelations()
        {
            return db.Posts.Include(post => post.Category).Include(post => post.Tags).ToList();
        }

        public Post GetById(int id)
        {
            return db.Posts.Where(p => p.Id == id).Include("Category").Include("Tags").FirstOrDefault();
        }

        public void Create(Post post, List<int> selectedTags)
        {
            //associazione dei tag selezionato dall'utente al modello

            post.Tags = new List<Tag>();
            foreach (int tagId in selectedTags)
            {
                //todo: implementare repository tag?
                Tag tag = db.Tags.Where(t => t.Id == tagId).FirstOrDefault();
                post.Tags.Add(tag);
            }

            db.Posts.Add(post);
            db.SaveChanges();
        }

        public void Update(Post post, Post formData, List<int>? selectedTags)
        {

          
            if (selectedTags == null)
            {
                selectedTags = new List<int>();
            }


            post.Title = formData.Title;
            post.Description = formData.Description;
            post.Image = formData.Image;
            post.CategoryId = formData.CategoryId;

            post.Tags.Clear();


            foreach (int tagId in selectedTags)
            {
                Tag tag = db.Tags.Where(t => t.Id == tagId).FirstOrDefault();
                post.Tags.Add(tag);
            }

            //db.Update(post);
            db.SaveChanges();
        }

        public void Delete(Post post)
        {
            db.Posts.Remove(post);
            db.SaveChanges();
        }


        //public void Update(int id, Post formData, List<int>? selectedTags)
        //{
        //    Post postItem = GetById(id);

        //    if(postItem == null)
        //    {
        //        //throw new
        //    }

        //    this.Update(postItem, formData, selectedTags);

        //}
    }

}
