namespace il_mio_primo_blog.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public List<Post> Posts { get; set; }

       
    }
}
