namespace il_mio_primo_blog.Models
{
    public class Tag
    {
        public int Id { get; set; }

        public string Title { get; set; }

        //relazione molti a molti con Post
        public List<Post>? Posts { get; set; }
    }
}
