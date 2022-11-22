using il_mio_primo_blog.Validator;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace il_mio_primo_blog.Models
{
    public class Post
    {

      
        public int Id { get; set; }

        // Post.cs

       
        
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(75, ErrorMessage = "Il titolo non può essere oltre i 75 caratteri")]
        [AlmenoDueParole]
        public string Title { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [Column(TypeName = "text")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
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
