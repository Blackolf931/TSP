using AutoMapper;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class GenericService<T, TEntity> : IGenericService<T, TEntity>
    {
        private readonly IRepositoryBase<TEntity> _repository;
        private readonly IMapper _mapper;

        public GenericService(IRepositoryBase<TEntity> repository, IMapper mapper)
        {
         //   var test = _repository.GetType();
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<T> AddAsync(T entity)
        {
            var mappedObject = _mapper.Map<TEntity>(entity);
            return _mapper.Map<T>(await _repository.AddAsync(mappedObject));
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var entityObject = await _repository.FindByIdAsync(id);
            if (entityObject is null)
            {
                return false;
            }
            else
            {
                var mapped = _mapper.Map<TEntity>(entityObject);
                await _repository.DeleteByIdAsync(mapped);
                return true;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var objectList = await _repository.FindAllAsync();
            return _mapper.Map<IEnumerable<T>>(objectList);
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            var entityObject = await _repository.FindByIdAsync(id);
            var mappedEmployee = _mapper.Map<T>(entityObject);
            return mappedEmployee;
        }
        public async Task<T> UpdateAsync(T entity)
        {
            var mappedObject = _mapper.Map<TEntity>(entity);
            var updateObject = await _repository.UpdateAsync(mappedObject);
            var mappedObjectResult = _mapper.Map<T>(updateObject);
            return mappedObjectResult;
        }

    }
}
