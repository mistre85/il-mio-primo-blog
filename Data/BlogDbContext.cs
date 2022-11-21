using il_mio_primo_blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace il_mio_primo_blog.Data
{
    public class BlogDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
              
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=il_mio_primo_blog_classe4;Integrated Security=True;Encrypt=false;");

        }
    }
}
