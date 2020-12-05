using Admin.Models;
using Microsoft.EntityFrameworkCore;

namespace Admin.Database
{
    public sealed class SchedulerContext : DbContext
    {
        public DbSet<Scheduler> Schedulers { get; set; }

        public SchedulerContext(DbContextOptions<SchedulerContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

    }
}