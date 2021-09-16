using AutoMapper;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class GenericService<T> : IGenericService<T>
    {
        private readonly IRepositoryBase<T> _repository;
        private readonly IMapper _mapper;

        public GenericService(IRepositoryBase<T> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            var mappedObject = _mapper.Map<T>(entity);
            return _mapper.Map<T>(await _repository.AddAsync(mappedObject));
        }

        public virtual async Task<bool> DeleteByIdAsync(int id)
        {
            var entityObject = await _repository.FindByIdAsync(id);
            if (entityObject is null)
            {
                return false;
            }
            else
            {
                await _repository.DeleteByIdAsync(entityObject);
                return true;
            }
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
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
        public virtual async Task<T> UpdateAsync(T entity)
        {
          //  var mappedObject = _mapper.Map<T>(entity);
            var updateObject = await _repository.UpdateAsync(entity);
            var mappedObjectResult = _mapper.Map<T>(updateObject);
            return mappedObjectResult;
        }

    }
}
