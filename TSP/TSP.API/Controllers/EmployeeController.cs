using AutoMapper;
using BLL.Models;
using BLL.Services;
using DAL.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TSP.API.ViewModels;

namespace TSP.API.Controllers
{
    public class EmployeeController : GenericController<Employee>
    {
        private readonly IEmployeeService _service;
        private readonly IMapper _mapper;
        //private readonly IValidator<Employee> _validator;
        public EmployeeController(IEmployeeService service, IMapper mapper) : base(service, mapper)
        {
            _mapper = mapper;
            _service = service;
          //  _validator = validator;
        }
        [HttpPut("Update")]
        public override async Task<ActionResult<Employee>> UpdateAsync([FromQuery] int id, [FromBody] Employee entity)
        {
           // await _validator.ValidateAndThrowAsync(entity);
            entity.Id = id;
            var mapped = _mapper.Map<Employee>(entity);
            //  return Ok(await _service.UpdateAsync(mapped));
            return Ok();
        }
    }
}