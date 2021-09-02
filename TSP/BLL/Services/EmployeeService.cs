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

        public EmployeeService(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddAsync(Employee employee)
        {
            var mappedEmployee = _mapper.Map<EmployeeEntity>(employee);
            await _repository.Add(mappedEmployee);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _repository.DeleteByIdAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            var employee = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<Employee>>(employee);
           
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            var employee = await _repository.GetByIdAsync(id);
            var mapped = _mapper.Map<Employee>(employee);
            return mapped;
        }

        public async Task UpdateAsync(Employee employee)
        {
            var mapped = _mapper.Map<EmployeeEntity>(employee);
            await _repository.UpdateAsync(mapped);
        }
    }
}
