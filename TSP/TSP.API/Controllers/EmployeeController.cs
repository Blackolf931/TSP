using AutoMapper;
using BLL.Models;
using BLL.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TSP.API.ViewModels;

namespace TSP.API.Controllers
{
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;
        private readonly IMapper _mapper;
        private readonly IValidator<EmployeeAddViewModel> _validator;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IEmployeeService service, IMapper mapper, IValidator<EmployeeAddViewModel> validator, ILogger<EmployeeController> logger)
        {
            _mapper = mapper;
            _service = service;
            _validator = validator;
            _logger = logger;
        }
        [HttpGet("GetAllEmployee")]
        public async Task<ActionResult<IEnumerable<EmployeeViewModel>>> GetAllEmployeeAsync()
        { 
            var employees = await _service.GetAllAsync();
            var mappedEmployees = _mapper.Map<IEnumerable<EmployeeViewModel>>(employees);
            return Ok(mappedEmployees); 
        }

        [HttpGet("GetEmployeeById")]
        public async Task<ActionResult<Employee>> GetEmployeeByIdAsync([FromQuery]int id)
        {
            try 
            {
               var employees = await _service.GetEmployeeByIdAsync(id);
                var mappedEmployees = _mapper.Map<EmployeeViewModel>(employees);
                return Ok(mappedEmployees);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Search error");
                return NotFound();
            }
        }
        [HttpDelete("DeleteEmployeeById")]
        public async Task<ActionResult<bool>> DeleteEmployeeAsync([FromQuery]int id)
        {
            try
            {
                await _service.DeleteByIdAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Delete error");
                return NotFound();
            }
        }

        [HttpPost("AddEmployee")]
        public async Task<ActionResult<Employee>> AddEmployee([FromBody] EmployeeAddViewModel employee)
        {
            try {
                await _validator.ValidateAndThrowAsync(employee);
                var mapped = _mapper.Map<Employee>(employee);
                return Ok(await _service.AddAsync(mapped));
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Add Error");
                return NoContent();
            }
         }
        [HttpPut("UpdateEmployee")]
        public async Task<ActionResult<Employee>> UpdateEmployeeAsync([FromQuery] int id, [FromBody] EmployeeAddViewModel employee)
        {
            try {
                await _validator.ValidateAndThrowAsync(employee);
                var mapped = _mapper.Map<Employee>(employee);
                mapped.Id = id;
                return Ok(await _service.UpdateAsync(mapped));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Update Eror");
                return NoContent();
            }
            }
    }
}
