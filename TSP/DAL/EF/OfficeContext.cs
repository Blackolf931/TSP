using System.Data.Entity;


namespace DAL.Entities
{
    public class OfficeContext : DbContext
    {
        /*  public DbSet<Employee> Employees { get; set; }

          static OfficeContext()
          {
              Database.SetInitializer<OfficeContext>(new DbInitializer());
          }

          public OfficeContext(string connectionString) : base(connectionString)
          {

          }
      }

      public class DbInitializer : DropCreateDatabaseIfModelChanges<OfficeContext>
      {
          protected override void Seed(OfficeContext db)
          {
              db.Employees.Add(new Employee { Name = "Test", SecondName = "Test", Age = 20 });
              db.Employees.Add(new Employee { Name = "Test1", SecondName = "Test1", Age = 20 });
              db.Employees.Add(new Employee { Name = "Test2", SecondName = "Test2", Age = 20 });
              db.SaveChanges();
          }
      }
        */
    }
}
