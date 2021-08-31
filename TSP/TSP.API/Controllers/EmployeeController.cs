using Contracts;
using Entities.DTO;
using Entities.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TSP.API.Controllers
{
    public class EmployeeController : ControllerBase
    {

        private readonly IRepositoryManager _repository;
        private readonly CheckData checkData = new();

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
            checkData.CheckStringOnValid(name);
            checkData.CheckStringOnValid(secondName);
            checkData.CheckStringOnValid(patronomic);
            checkData.CheckStringOnValid(position);
            checkData.CheckAge(age);
            checkData.CheckOfficeId(id, _repository);
            _repository.Employee.Add(id, name, secondName, patronomic, age, position, officeId);
            return Ok("Employee has been add");
        }
        [HttpPost("UpdateEmployee")]
        public ActionResult<IEnumerable<string>> UpdateEmployee(int id, string name, string secondName, string patronomic, int age, string position, int officeId)
        {
           
            checkData.CheckEmployeeId(id, _repository);
            checkData.CheckStringOnValid(name);
            checkData.CheckStringOnValid(secondName);
            checkData.CheckStringOnValid(patronomic);
            checkData.CheckStringOnValid(position);
            checkData.CheckOfficeId(id, _repository);
            checkData.CheckAge(age);
            _repository.Employee.Update(id, name, secondName, patronomic, age, position, officeId);
            return Ok("Employee has been update");
        }
    }
}
