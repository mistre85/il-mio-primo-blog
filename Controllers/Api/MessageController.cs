using il_mio_primo_blog.Data;
using il_mio_primo_blog.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace il_mio_primo_blog.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private BlogDbContext db;

        public MessageController(BlogDbContext _db)
        {
            db = _db; 
        }
        [HttpPost]
        // public void Post(Message message) equivalente anche senza [FormBody]
        public IActionResult Create([FromBody] Message message)
        {

            try
            {
                db.Messages.Add(message);
                db.SaveChanges();

            }catch(Exception e)
            {
                return UnprocessableEntity(e.Message);
            }

            return Ok(message);
        }
    }
}
