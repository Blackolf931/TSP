using AutoMapper;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;
        private readonly IStrategyService _strategyService;

        public EmployeeService(IEmployeeRepository repository, IMapper mapper, IStrategyService strategy)
        {
            _repository = repository;
            _mapper = mapper;
            _strategyService = strategy;
        }

        public async Task<Employee> AddAsync(Employee employee)
        {
            var mappedEmployee = _mapper.Map<EmployeeEntity>(employee);
            return _mapper.Map<Employee>(await _repository.AddAsync(mappedEmployee));
        }

        public Task<bool> DeleteByIdAsync(int id)
        {
           return _repository.DeleteByIdAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            var employee = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<Employee>>(employee);
        }

        public async Task<EmployeeGetById> GetEmployeeByIdAsync(int id)
        {
            var employee = await _repository.GetByIdAsync(id);
            var mappedEmployee = _mapper.Map<EmployeeGetById>(employee);
            mappedEmployee.AdditionalInformation = _strategyService.ISValidStrategy(employee.Id);
            return mappedEmployee;
        }

        public async Task<Employee> UpdateAsync(Employee employee)
        {
            var mapped = _mapper.Map<EmployeeEntity>(employee);
            return _mapper.Map<Employee>(await _repository.UpdateAsync(mapped));
        }
    }
}
