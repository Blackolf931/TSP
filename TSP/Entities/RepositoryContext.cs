using Entities.Model;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Employee> Employees {get;set; }
    }
}
