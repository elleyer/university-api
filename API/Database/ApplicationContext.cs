using Admin.Models;
using Microsoft.EntityFrameworkCore;

namespace Admin.Database
{
    public sealed class ApplicationContext : DbContext
    {
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Models.User.User> Users { get; set; }
        
        public DbSet<News> News { get; set; }
        
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}