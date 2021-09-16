using AutoMapper;
using BLL.Models;
using BLL.Services;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TSP.API.Controllers
{
    [ApiController]
    public class GenericController<T> : ControllerBase where T: class
    {
        private readonly IGenericService<T> _service;
        private readonly IMapper _mapper;
      //  private readonly IValidator<T> _validator;
        protected GenericController(IGenericService<T> service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
         //   _validator = validator;
        }

       /* public GenericController(IEmployeeService service, IMapper mapper)
        {
            _mapper = mapper;
            _service = (IGenericService<T>?)service;
        }*/

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<T>>> GetAllAsync()
        {
            var employees = await _service.GetAllAsync();
            var mappedEmployees = _mapper.Map<IEnumerable<T>>(employees);
            return Ok(mappedEmployees);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<T>> GetEmployeeByIdAsync([FromQuery] int id)
        {
            var employees = await _service.GetByIdAsync(id);
            var mappedEmployees = _mapper.Map<T>(employees);
            return Ok(mappedEmployees);
        }
        [HttpDelete("DeleteEmployeeById")]
        public async Task<ActionResult<bool>> DeleteEmployeeAsync([FromQuery] int id)
        {
            await _service.DeleteByIdAsync(id);
            return Ok();
        }

        [HttpPost("AddNew")]
        public async Task<ActionResult<T>> AddAsync([FromBody] T entity)
        {
      //      await _validator.ValidateAndThrowAsync(entity);
            var mapped = _mapper.Map<T>(entity);
            return Ok(await _service.AddAsync(mapped));
        }
        [HttpPut("Update")]
        public virtual async Task<ActionResult<T>> UpdateAsync([FromQuery] int id, [FromBody] T entity)
        {
       //     await _validator.ValidateAndThrowAsync(entity);
            var mapped = _mapper.Map<T>(entity);
            return Ok(await _service.UpdateAsync(mapped));
        }
    }
}
