using Contracts;
using Entities;
using Entities.DTO;
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
        private readonly RepositoryContext _repositoryContext;

        public EmployeeRepository(RepositoryContext repositoryContext): base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public void Add(int id, string name, string secondName, string patronomic, int age, string position, int officeId)
        {
            _repositoryContext.Employees.Add(new EmployeeDto(id, name, secondName, patronomic, age, position, officeId));
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

        public void Update(int id, string name, string secondName, string patronomic, int age, string position, int officeId)
        {
            _repositoryContext.Employees.Update(new EmployeeDto(id, name, secondName, patronomic, age, position, officeId));
        }
    }
}
