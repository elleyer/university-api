using Admin.Models;
using Microsoft.EntityFrameworkCore;

namespace Admin.Database
{
    public sealed class NewsContext : DbContext
    {
        public DbSet<Scheduler> News { get; set; }

        public NewsContext(DbContextOptions<SchedulerContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

    }
}