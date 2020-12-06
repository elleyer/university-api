using Admin.Models;
using Microsoft.EntityFrameworkCore;

namespace Admin.Database
{
    public sealed class SchedulerContext : DbContext
    {
        public DbSet<SchedulerDay> SchedulerDay { get; set; }

        public SchedulerContext(DbContextOptions<SchedulerContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}