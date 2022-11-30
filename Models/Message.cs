using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel.DataAnnotations;

namespace il_mio_primo_blog.Models
{
    public class Message
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public string Text { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [EmailAddress(ErrorMessage = "La mail deve avere un formato corretto")]
        public string Email { get; set; }

    }
}
