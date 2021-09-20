using DAl.EF;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly RepositoryContext _repositoryContext;

        public RepositoryBase(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public virtual async Task<IEnumerable<TEntity>> FindAllAsync()
        {
            var result = await _repositoryContext.Set<TEntity>().ToListAsync();
            return result;
        }

        public ValueTask<TEntity> FindByIdAsync(int id)
        {
            return _repositoryContext.Set<TEntity>().FindAsync(id);
        }

        public async Task DeleteByIdAsync(TEntity entity)
        {
            _repositoryContext.Set<TEntity>().Remove(entity);
            await _repositoryContext.SaveChangesAsync();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            _repositoryContext.Set<TEntity>().Add(entity);
            await _repositoryContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _repositoryContext.Set<TEntity>().Update(entity);
            await _repositoryContext.SaveChangesAsync();
            return entity;
        }
    }
}
