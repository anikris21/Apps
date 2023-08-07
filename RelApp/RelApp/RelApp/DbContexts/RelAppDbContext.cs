using Microsoft.EntityFrameworkCore;
using RelApp.Models;

namespace RelApp.DbContexts
{
    // :DbContext
    public class RelAppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Department { get; set; }

        public RelAppDbContext(DbContextOptions<RelAppDbContext> options) : base(options)
        {
        }

    }
}
