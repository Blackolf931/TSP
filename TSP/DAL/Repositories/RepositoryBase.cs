using DAl.BusinessLogic;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.BusinessLogic
{
   public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext _repositoryContext;

        protected RepositoryBase(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public async Task<IEnumerable<T>> FindAllAsync()
        {
            return await _repositoryContext.Set<T>().ToListAsync();
        }

        public async Task<T> FindByIdAsync(int id)
        {
            return await _repositoryContext.Set<Task<T>>().Find(id);
        }

        public async Task DeleteByIdAsync(T entity)
        {
            _repositoryContext.Set<T>().Remove(entity);
            await _repositoryContext.SaveChangesAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            _repositoryContext.Set<T>().Add(entity);
            await _repositoryContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _repositoryContext.Set<T>().Update(entity);
            await _repositoryContext.SaveChangesAsync();
            return entity;
        }

        public Task<object> AddAsync(EmployeeEntity mappedEmployee)
        {
            throw new NotImplementedException();
        }
    }
}
