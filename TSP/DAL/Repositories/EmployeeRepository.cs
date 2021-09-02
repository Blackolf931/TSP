
using DAl.BusinessLogic;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.BusinessLogic
{
    public class EmployeeRepository : RepositoryBase<EmployeeEntity>, IEmployeeRepository
    {
        private readonly RepositoryContext _repositoryContext;

        public EmployeeRepository(RepositoryContext repositoryContext): base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public async Task Add(EmployeeEntity entity)
        {
            await _repositoryContext.Employees.AddAsync(entity);
            await _repositoryContext.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var employee = await _repositoryContext.Employees.FindAsync(id);
            _repositoryContext.Employees.Remove(employee);
            await _repositoryContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<EmployeeEntity>> GetAllAsync()
        {
            return await _repositoryContext.Employees.Include(x => x.Office).ToListAsync();
        }

        public async Task<EmployeeEntity> GetByIdAsync(int id)
        {
            return await _repositoryContext.Employees.FindAsync(id);
        }

        public async Task UpdateAsync(EmployeeEntity entity)
        {
           _repositoryContext.Employees.Update(entity);
           await _repositoryContext.SaveChangesAsync();
        }
    }
}
