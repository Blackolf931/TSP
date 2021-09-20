using AutoMapper;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EmployeeService : GenericService<Employee, EmployeeEntity>, IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;
        private readonly IEnumerable<IStrategy> _strategy;

        public EmployeeService(IEmployeeRepository repository, IMapper mapper, IEnumerable<IStrategy> strategy) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _strategy = strategy;
        }

        public override async Task<Employee?> GetByIdAsync(int id)
        {
            var entityObject = await _repository.FindByIdAsync(id);
            if (entityObject is null)
            {
                return null;
            }
            var mappedEmployee = _mapper.Map<Employee>(entityObject);
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
        public override async Task<IEnumerable<Employee>> GetAllAsync()
        {
            var result = await _repository.FindAllAsync();
            return _mapper.Map<IEnumerable<Employee>>(result);
        }
    }
}