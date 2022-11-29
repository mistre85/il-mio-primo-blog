using il_mio_primo_blog.Models;
using il_mio_primo_blog.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace il_mio_primo_blog.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        IPostRepository _postRepository;

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public IActionResult Get()
        {
            List<Post> posts = _postRepository.All();
            return Ok(posts);
           
        }

        public IActionResult Search(string? title)
        {

            List<Post> posts = _postRepository.SearchByTitle(title);

            return Ok(posts);

        }

        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            Post post = _postRepository.GetById(id);

            return Ok(post);
        }
    }


}
