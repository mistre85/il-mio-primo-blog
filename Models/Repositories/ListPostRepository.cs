using System.Runtime.Serialization;

namespace il_mio_primo_blog.Models.Repositories
{
    public class ListPostRepository : IPostRepository
    {
        public static List<Post> Posts = new List<Post>();

        public ListPostRepository()
        {
            //non lo possiamo fare perchè ognu nuova possibile istanza ci cancella la lista
            //Posts = new List<Post>();
        }

        public List<Post> All()
        {
            return Posts;
        }

        public void Create(Post post, List<int> selectedTags)
        {
            //simuliamo la primary key
            post.Id = Posts.Count;
            post.Category = new Category() { Id = 1, Title = "Fake cateogry" };

            //simulazione da implentare con ListTagRepository
            post.Tags = new List<Tag>();

            TagToPost(post, selectedTags);
            //fine simulazione

            Posts.Add(post);
        }

        private static void TagToPost(Post post, List<int> selectedTags)
        {
            post.Category = new Category() { Id = 1, Title = "Fake cateogry" };

            foreach (int tagId in selectedTags)
            {
                post.Tags.Add(new Tag() { Id = tagId, Title = "Fake tag " + tagId });
            }
        }

        public void Delete(Post post)
        {
            Posts.Remove(post);
        }

        public Post GetById(int id)
        {
            Post post = Posts.Where(post => post.Id == id).FirstOrDefault();

            post.Category = new Category() { Id = 1, Title = "Fake cateogry" };

            return post;
        }

        public void Update(Post post, Post formData, List<int>? selectedTags)
        {
            post = formData;
            post.Category = new Category() { Id = 1, Title = "Fake cateogry" };

            post.Tags = new List<Tag>();

            //simulazione da implentare con ListTagRepository

            TagToPost(post, selectedTags);
            //fine simulazione


        }

    }
}
