using AutoMapper;
using BLL.DTO;
using BLL.Infastructure;
using BLL.Interface;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace BLL.Services
{
    public class EmployeeService
    {
      /*  IUnitOfWork Database { get; set; }
        public EmployeeService(IUnitOfWork unit)
        {
            Database = unit;
        }

        public void AddEmployee(EmployeeDTO employeeDto)
        {
            Employee employee = Database.Employes.Get(employeeDto.Id);
            if(employee == null)
            {
                throw new ValidationException("Сотрудник не найден", "");
            }
            Employee empl = new Employee
            {
                Name = "Test3",
                SecondName = "Test3",
                Age = 23
            };
            Database.Employes.Create(empl);
            Database.Save();
        }



        public EmployeeDTO GetEmployee(int? id)
        {
            if (id is null) 
            {
                throw new ValidationException("Id does not exist", "");
            }
            var employee = Database.Employes.Get(id.Value);
            if (employee is null)
            {
                throw new ValidationException("Employee not founded", "");
            }
            return new EmployeeDTO { Name = employee.Name, SecondName = employee.SecondName, Age = employee.Age };
        }

        public IEnumerable<EmployeeDTO> GetEmpoyes()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Employee>, List<EmployeeDTO>>(Database.Employes.GetAll());
        }

        public void Dispose()
        {
            Database.Dispose();
        }*/

        //Test string
    }
}
