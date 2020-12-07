using Admin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Admin.Database
{
    public sealed class FacultyContext : DbContext
    {
        public DbSet<Faculty> Faculties { get; set; }

        public FacultyContext(DbContextOptions<FacultyContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}