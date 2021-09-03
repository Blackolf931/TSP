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
        public async Task<bool> DeleteByIdAsync(int id)
        {
            var office = await _repositoryContext.Offices.FindAsync(id);
            if (office is null)
            {
                return false;
            }
            else
            {
                _repositoryContext.Offices.Remove(office);
                await _repositoryContext.SaveChangesAsync();
                return true;
            }
        }

        public async Task<OfficeEntity> AddAsync(OfficeEntity entity)
        {
            await _repositoryContext.Offices.AddAsync(entity);
            await _repositoryContext.SaveChangesAsync();
            return entity;
        }

        public async Task<OfficeEntity> UpdateAsync(OfficeEntity entity)
        {
           _repositoryContext.Offices.Update(entity);
           await _repositoryContext.SaveChangesAsync();
            return entity;
        }
    }
}
