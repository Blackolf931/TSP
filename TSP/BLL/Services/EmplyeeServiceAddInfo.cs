using AutoMapper;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
   /* public class EmplyeeServiceAddInfo<Employee> : IGenericService<Employee>
    {
       /* private readonly IRepositoryBase<Employee> _repository;
        private readonly IMapper _mapper;
        private readonly IEnumerable<IStrategy> _strategy;

        public EmplyeeServiceAddInfo(IRepositoryBase<Employee> repository, IMapper mapper, IEnumerable<IStrategy> strategy)
        {
            _repository = repository;
            _mapper = mapper;
            _strategy = strategy;
        }

        public override async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            var entityObject = await _repository.FindByIdAsync(id);
            var mappedEmployee = _mapper.Map<Employee>(entityObject);
            if (entityObject is not null)
            {
                foreach (var strategy in _strategy)
                {
                    if (strategy.IsValidStrategy(entityObject))
                    {
                        mappedEmployee.AdditionalInformation = strategy.SetInformation();
                        break;
                    }
                }
                return mappedEmployee;
            }
            else
            {
                return entityObject;
            }
        }
    }*/
}
