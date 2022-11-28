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

        public IActionResult Test()
        {
            
            return Ok("test");

        }

        public IActionResult Get()
        {
            List<Post> posts = _postRepository.All();
            return Ok(posts);
           
        }
    }
}
