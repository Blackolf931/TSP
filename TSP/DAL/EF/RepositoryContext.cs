using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAl.EF
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions? options) : base(options)
        {
        }
        public DbSet<OfficeEntity>? Offices { get; set; }
        public DbSet<EmployeeEntity>? Employees { get; set; }
    }
}