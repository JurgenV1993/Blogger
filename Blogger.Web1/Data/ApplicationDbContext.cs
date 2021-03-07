using Blogger.Web1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Blogger.Web1.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserApp>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Blogger.Web1.Models.ViewModels.CreateModel> CreateModel { get; set; }
        public DbSet<Blogger.Web1.Models.ViewModels.LoginModel> LoginModel { get; set; }
        public DbSet<Blogger.Web1.Models.ViewModels.CategoryModel> CategoryModel { get; set; }
    }
}
