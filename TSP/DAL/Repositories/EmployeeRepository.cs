
using DAl.BusinessLogic;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;


namespace DAL.BusinessLogic
{
    public class EmployeeRepository : RepositoryBase<EmployeeEntity>, IEmployeeRepository
    {
        private readonly RepositoryContext _repositoryContext;

        public EmployeeRepository(RepositoryContext repositoryContext): base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public void Add(EmployeeEntity entity)
        {
            _repositoryContext.Employees.Add(entity);
        }

        public void DeleteById(int id)
        {
            _repositoryContext.Employees.Remove(_repositoryContext.Employees.Find(id));
        }

        public IEnumerable<EmployeeEntity> GetAll()
        {
            return _repositoryContext.Employees.Include(x => x.Office).ToList();
        }

        public EmployeeEntity GetById(int id)
        {
            return _repositoryContext.Employees.Find(id);
        }

        public new void Update(EmployeeEntity entity)
        {
            _repositoryContext.Employees.Update(entity);
        }
    }
}
