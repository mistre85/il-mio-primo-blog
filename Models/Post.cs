using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace il_mio_primo_blog.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        public string Image { get; set; }

        public Post()
        {

        }

        public Post(string title, string description, string image)
        {
            this.Title = title;
            this.Description = description;
            this.Image = image;
        }
    }
}
