using System;
using System.Collections.Generic;
using System.Text;
using Blogger.Web1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Blogger.Web1.Models.ViewModels;

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
    }
}
