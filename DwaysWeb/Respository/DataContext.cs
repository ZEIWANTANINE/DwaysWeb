using DwaysWeb.Respository.Components;
using DwaysWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace DwaysWeb.Respository
{
    public class DataContext: IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        
        }
        public DbSet<Models.Products>? Products { get; set; }
        public DbSet<Catergory>? Catergories { get; set; }
        public DbSet<IdentityUser> Users { get; set; }
        public DbSet<Models.Blog>? Blogs { get; set; }
    }
}
