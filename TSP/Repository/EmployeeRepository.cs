using Contracts;
using Entities;
using Entities.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        private RepositoryContext _repositoryContext;

        public EmployeeRepository(RepositoryContext repositoryContext): base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public void DeleteById(int id)
        {
            _repositoryContext.Employees.Remove(_repositoryContext.Employees.Find(id));
        }

        public IEnumerable<Employee> GetAll()
        {
            return _repositoryContext.Employees.Include(x => x.Office).ToList();
        }

        public Employee GetById(int id)
        {
            return _repositoryContext.Employees.Find(id);
        }
    }
}
