using BLL.DTO;
using DAL.Interfaces;
using System.Collections.Generic;

namespace BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Employee> GetAll()
        {
            List<Employee> employeeList = new();
           var employees = _repository.GetAll();
            foreach(var el in employees)
            {
                employeeList.Add(new Employee
                {
                    Id = el.Id,
                    Name = el.Name,
                    Age = el.Age,
                    Office = new Office { Address = el.Office.Address, Name = el.Office.Name, Country = el.Office.Country, Id = el.Office.Id },
                    Patronomic = el.Patronomic,
                    Position = el.Position,
                    SecondName = el.SecondName
                });
            }
            return employeeList;
        }
    }
}
