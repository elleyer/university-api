using Admin.Models;
using Microsoft.EntityFrameworkCore;

namespace Admin.Database
{
    public sealed class ApplicationContext : DbContext
    {
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Models.Mod.ModEntity> Moderators { get; set; }
        
        public DbSet<News> News { get; set; }
        
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}