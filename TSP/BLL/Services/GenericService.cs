using AutoMapper;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class GenericService<T, TEntity> : IGenericService<T, TEntity>
    {
        private readonly IRepositoryBase<TEntity> _repository;
        private readonly IMapper _mapper;
    //    private readonly IEnumerable<IStrategy> _strategy;

        public GenericService(IRepositoryBase<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
          //  _strategy = strategy;
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

        public async Task<T> GetByIdAsync(int id)
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
      /*  public override async Task<Employee> GetByIdAsync(int id)
        {
            var entityObject = await _repository.FindByIdAsync(id);
            var mappedEmployee = _mapper.Map<Employee>(entityObject);
            if (entityObject is not null)
            {
                foreach (var strategy in _strategy)
                {
                    if (strategy.IsValidStrategy(mappedEmployee.Age))
                    {
                        mappedEmployee.AdditionalInformation = strategy.SetInformation();
                        break;
                    }
                }
                return mappedEmployee;
            }
            else
            {
                return null;
            }
        }*/
    }
}
