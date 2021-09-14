using AutoMapper;
using BLL.Models;
using BLL.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TSP.API.ViewModels;

namespace TSP.API.Controllers
{
   /* public class EmployeeController : ControllerBase
    {
      //  private readonly IGenericService<Employee,Emplo> _service;
        private readonly IMapper _mapper;
        private readonly IValidator<EmployeeAddViewModel> _validator;

        public EmployeeController(IGenericService<Employee> service, IMapper mapper, IValidator<EmployeeAddViewModel> validator)
        {
            _mapper = mapper;
      //      _service = service;
            _validator = validator;
        }
        [HttpGet("GetAllEmployee")]
        public async Task<ActionResult<IEnumerable<EmployeeViewModel>>> GetAllEmployeeAsync()
        {
            var employees = await _service.GetAllAsync();
            var mappedEmployees = _mapper.Map<IEnumerable<EmployeeViewModel>>(employees);
            return Ok(mappedEmployees);
        }

        [HttpGet("GetEmployeeById")]
        public async Task<ActionResult<Employee>> GetEmployeeByIdAsync([FromQuery] int id)
        {
            var employees = await _service.GetByIdAsync(id); 
              //  _service.GetEmployeeByIdAsync(id);
            var mappedEmployees = _mapper.Map<EmployeeViewModel>(employees);
            return Ok(mappedEmployees);
        }
        [HttpDelete("DeleteEmployeeById")]
        public async Task<ActionResult<bool>> DeleteEmployeeAsync([FromQuery] int id)
        {
            await _service.DeleteByIdAsync(id);
            return Ok();
        }

        [HttpPost("AddEmployee")]
        public async Task<ActionResult<Employee>> AddEmployee([FromBody] EmployeeAddViewModel employee)
        {
            await _validator.ValidateAndThrowAsync(employee);
            var mapped = _mapper.Map<Employee>(employee);
            return Ok(await _service.AddAsync(mapped));
        }
        [HttpPut("UpdateEmployee")]
        public async Task<ActionResult<Employee>> UpdateEmployeeAsync([FromQuery] int id, [FromBody] EmployeeAddViewModel employee)
        {
            await _validator.ValidateAndThrowAsync(employee);
            var mapped = _mapper.Map<Employee>(employee);
            mapped.Id = id;
            return Ok(await _service.UpdateAsync(mapped));
        }
    }*/
}