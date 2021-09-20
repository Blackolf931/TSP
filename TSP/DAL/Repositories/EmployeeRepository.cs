using DAl.EF;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class EmployeeRepository : RepositoryBase<EmployeeEntity>, IEmployeeRepository
    {
        private readonly RepositoryContext _repositoryContext;
        public EmployeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public override async Task<IEnumerable<EmployeeEntity>> FindAllAsync()
        {
            var result = await _repositoryContext.Set<EmployeeEntity>().Include(x => x.Office).ToListAsync();
            return result;
        }
    }
}
