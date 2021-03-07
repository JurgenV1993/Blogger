using Blogger.Models;
using Microsoft.EntityFrameworkCore;


namespace Blogger.DAL
{
    public class BloggerCotext : DbContext
    {
        public DbSet<BL_Category> Categories { get; set; }
        public DbSet<BL_Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=BloggerDatabase;Integrated Security=True");
        }
    }
}
