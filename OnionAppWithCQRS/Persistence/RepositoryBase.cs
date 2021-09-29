using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly RepositoryContext _repositoryContext;

        public RepositoryBase(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            _repositoryContext.Add(entity);
            await _repositoryContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteByIdAsync(TEntity entity)
        {
            _repositoryContext.Remove(entity);
            await _repositoryContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> FindAllAsync()
        {
            return await _repositoryContext.Set<TEntity>().ToListAsync();
        }

        public ValueTask<TEntity> FindByIdAsync(int id)
        {
            return _repositoryContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _repositoryContext.Set<TEntity>().Update(entity);
            await _repositoryContext.SaveChangesAsync();
            return entity;
        }
    }
}