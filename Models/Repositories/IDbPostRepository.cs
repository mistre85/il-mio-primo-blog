namespace il_mio_primo_blog.Models.Repositories
{
    public interface IDbPostRepository
    {
        List<Post> All();
        void Create(Post post, List<int> selectedTags);
        void Delete(Post post);
        Post GetById(int id);
        void Update(Post post, Post formData, List<int>? selectedTags);
    }
}