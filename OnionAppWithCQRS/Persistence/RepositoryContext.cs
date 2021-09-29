using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
        }
        public DbSet<Office> Offices { get; set; }
    }
}