namespace il_mio_primo_blog.Models.Repositories
{
    public interface IPostRepository
    {
        List<Post> All();
        void Create(Post post, List<int> selectedTags);

        Post GetById(int id);

        void Delete(Post post);
        void Update(Post post, Post formData, List<int>? selectedTags);
    
    }
}