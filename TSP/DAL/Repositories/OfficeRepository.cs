using DAl.EF;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class OfficeRepository : RepositoryBase<OfficeEntity>, IOfficeRepository
    {
        private RepositoryContext _repositoryContext;
        public OfficeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public async Task<IEnumerable<OfficeEntity>> FindAllOfficeAsync()
        {
            var employees = await _repositoryContext.Set<OfficeEntity>().Include(x => x.Employess).ToListAsync();
            return employees;
        }
    }
}
