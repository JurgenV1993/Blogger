using Blogger.Models;
using Microsoft.EntityFrameworkCore;


namespace Blogger.DAL
{
    public class MyCotext : DbContext
    {
        public DbSet<BL_Category> Categories { get; set; }
        public DbSet<BL_Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=Blogger;Integrated Security=True");
        }
    }
}
