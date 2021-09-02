using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAl.BusinessLogic
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<OfficeEntity> Offices { get; set; }
        public DbSet<EmployeeEntity> Employees {get;set; }
    }
}
