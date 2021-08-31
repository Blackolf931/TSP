using Contracts;
using Entities.DTO;
using Entities.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSP.API.Exceptions;

namespace TSP.API.Controllers
{
    public class EmployeeController : ControllerBase
    {

        private readonly IRepositoryManager _repository;

        public EmployeeController(IRepositoryManager repository)
        {
            _repository = repository;
        }
        [HttpGet("GetAllEmployee")]
        public ActionResult<IEnumerable<Employee>> GetAllEmployee()
        {
          return Ok(_repository.Employee.GetAll());    
        }

        [HttpGet("GetEmployeeById")]
        public ActionResult<Employee> GetEmployeeById(int id)
        {
            return _repository.Employee.GetById(id);
        }
        [HttpDelete("DeleteEmployeeById")]
        public ActionResult<IEnumerable<string>> DeleteEmployee(int id)
        {
            _repository.Employee.DeleteById(id);
            return new string[] { "Employee has been delete"};
        }
        [HttpPost("AddEmployee")]
        public ActionResult<IEnumerable<string>> AddEmployee(int id, string name, string secondName, string patronomic, int age, string position, int officeId)
        {
            ValidData(new EmployeeDto(id, name, secondName, patronomic, age, position, officeId));
            _repository.Employee.Add(id, name, secondName, patronomic, age, position, officeId);
            return Ok("Employee has been add");
        }
        [HttpPost("UpdateEmployee")]
        public ActionResult<IEnumerable<string>> UpdateEmployee(int id, string name, string secondName, string patronomic, int age, string position, int officeId)
        {
            ValidData(new EmployeeDto(id, name, secondName, patronomic, age, position, officeId));
            _repository.Employee.Update(id, name, secondName, patronomic, age, position, officeId);
            return Ok("Employee has been update");
        }

        private static void ValidData(EmployeeDto dto)
        {
            new GenerateEmployeeException(dto);
        }
    }
}
