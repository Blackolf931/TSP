using AutoMapper;
using BLL.Models;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EmployeeServiceGettAdditionalInfo<T, TEntity> : GenericService<T,TEntity>, IGenericService<T,TEntity>
    {
        public IRepositoryBase<TEntity> _repository;
        public IMapper _mapper;
        private readonly IEnumerable<IStrategy> _strategy;

        public EmployeeServiceGettAdditionalInfo(IRepositoryBase<TEntity> repository, IMapper mapper, IEnumerable<IStrategy> strategy) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _strategy = strategy;
        }

        public override async Task<T> GetByIdAsync(int id)
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
                return _mapper.Map<T>(mappedEmployee);
            }
            else
            {
                return _mapper.Map<T>(entityObject);
            }
        }
    }
}
