using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace TSP.API
{
    public class OfficeContext : DbContext
    {
        public DbSet<EmployeeDTO> Employess { get; set; }
    }
}
