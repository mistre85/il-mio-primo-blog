using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace il_mio_primo_blog.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Title { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<Post> Posts { get; set; }

       
    }
}
