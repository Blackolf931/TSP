using AutoMapper;
using BLL.Models;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TSP.API.ViewModels;

namespace TSP.API.Controllers
{
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
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
            var employees = await _service.GetEmployeeByIdAsync(id);
            var mappedEmployees = _mapper.Map<EmployeeViewModel>(employees);
            return Ok(mappedEmployees);
        }
        [HttpDelete("DeleteEmployeeById")]
        public async Task<ActionResult<string>> DeleteEmployeeAsync([FromQuery]int id)
        {
            if (await _service.DeleteByIdAsync(id) == true)
            {
                return "Employee has been delete";
            }
            else
            {
                Response.StatusCode = 500;
                return "Employee can't been find";
            }
        }
        [HttpPost("AddEmployee")]
         public async Task<ActionResult<Employee>> AddEmployee([FromBody] EmployeeAddViewModel employee)
         {
            var mapped = _mapper.Map<Employee>(employee);
            return Ok(await _service.AddAsync(mapped));
         }
         [HttpPut("UpdateEmployee")]
         public async Task<ActionResult<Employee>> UpdateEmployeeAsync([FromQuery]int id, [FromBody]EmployeeAddViewModel employee)
         {
            var mapped = _mapper.Map<Employee>(employee);
            mapped.Id = id;
            return Ok(await _service.UpdateAsync(mapped));
         }
    }
}
