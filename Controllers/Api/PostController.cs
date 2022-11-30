using il_mio_primo_blog.Models;
using il_mio_primo_blog.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace il_mio_primo_blog.Controllers.Api
{
    [Route("api/[controller]",Order = 1)]
    [ApiController]
    public class PostController : ControllerBase
    {
        IPostRepository _postRepository;

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }


        // api/post
        // api/post?title=[query]
        [HttpGet]
        public IActionResult Get(string? title)
        {
            List<Post> posts = _postRepository.SearchByTitle(title);

            return Ok(posts);

        }

        // api/post/[id]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Post post = _postRepository.GetById(id);

            return Ok(post);
        }

        // /api/post
        [HttpPost]
        public IActionResult Update(Post post)
        {
            return Ok("ok");
        }
    }


}
