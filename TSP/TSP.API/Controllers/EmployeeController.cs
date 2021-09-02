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
        private readonly IOfficeService _officeService;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService service, IMapper mapper, IOfficeService officeService)
        {
            _officeService = officeService;
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
        public async Task<ActionResult<Employee>> GetEmployeeByIdAsync(int id)
        {
            var employees = await _service.GetEmployeeByIdAsync(id);
            var mappedEmployees = _mapper.Map<EmployeeViewModel>(employees);
            return Ok(mappedEmployees);
        }
        [HttpDelete("DeleteEmployeeById")]
        public async Task<ActionResult<IEnumerable<string>>> DeleteEmployeeAsync(int id)
        {
            await _service.DeleteByIdAsync(id);
            return new string[] { "Employee has been delete" };
        }
        [HttpPost("AddEmployee")]
         public async Task<ActionResult<IEnumerable<string>>> AddEmployee(EmployeeViewModel employee)
         {
            var mapped = _mapper.Map<Employee>(employee);
            await _service.AddAsync(mapped);
            return Ok("Employee has been add");
         }
         [HttpPut("UpdateEmployee")]
         public async Task<ActionResult<IEnumerable<string>>> UpdateEmployeeAsync([FromQuery]int id, [FromBody]EmployeeAddViewModel employee)
         {
            var office = await _officeService.GetByIdAsync(2);
            var mapped = _mapper.Map<Employee>(employee);
            mapped.Id = id;
            mapped.Office = office;
            await _service.UpdateAsync(mapped);
             return Ok("Employee has been update");
         }
    }
}
