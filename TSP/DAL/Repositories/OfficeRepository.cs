using DAl.BusinessLogic;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.BusinessLogic
{
    public class OfficeRepository : RepositoryBase<OfficeEntity>, IOfficeRepository
    {
        private readonly RepositoryContext _repositoryContext;
        public OfficeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public async Task<IEnumerable<OfficeEntity>> GetAllAsync()
        {
            return await _repositoryContext.Offices.Include(x => x.Employess).ToListAsync();
        }
        public async Task<OfficeEntity> GetByIdAsync(int id)
        {
           return await _repositoryContext.Offices.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public void Save()
        {
            throw new NotImplementedException();
        }
        public async Task RemoveByIdAsync(int id)
        {
            var officeId = await _repositoryContext.Offices.FindAsync(id);
           _repositoryContext.Offices.Remove(officeId);
           await _repositoryContext.SaveChangesAsync();
        }

        public async Task Add(OfficeEntity entity)
        {
            await _repositoryContext.Offices.AddAsync(entity);
            await _repositoryContext.SaveChangesAsync();
        }

        public async Task Update(OfficeEntity entity)
        {
           _repositoryContext.Offices.Update(entity);
           await _repositoryContext.SaveChangesAsync();
        }
    }
}
