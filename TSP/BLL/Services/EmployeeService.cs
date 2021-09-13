﻿using AutoMapper;
using BLL.Infastructure;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;
        private readonly IEnumerable<IStrategy> _strategy;

        public EmployeeService(IEmployeeRepository repository, IMapper mapper, IEnumerable<IStrategy> strategy)
        {
            _repository = repository;
            _mapper = mapper;
            _strategy = strategy;
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

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            var employee = await _repository.GetByIdAsync(id);
            var mappedEmployee = _mapper.Map<Employee>(employee);
            if(employee is null)
            {
                return null;
            }
            foreach (var strategy in _strategy)
            {
                if (strategy.IsValidStrategy(employee.Age))
                {
                    mappedEmployee.AdditionalInformation = strategy.SetInformation();
                    break;
                }
            }
            return mappedEmployee;
        }

        public async Task<Employee> UpdateAsync(Employee employee)
        {
            var mapped = _mapper.Map<EmployeeEntity>(employee);
            var updateEmployee = await _repository.UpdateAsync(mapped);
            var mappedEmployee = _mapper.Map<Employee>(updateEmployee);
            return mappedEmployee;
        }
    }
}
