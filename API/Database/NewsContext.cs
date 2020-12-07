using Admin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

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