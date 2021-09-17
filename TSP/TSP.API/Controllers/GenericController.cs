using AutoMapper;
using BLL.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TSP.API.Controllers
{
    [ApiController]
    public class GenericController<T> : ControllerBase where T : class
    {
        private readonly IGenericService<T> _service;
        private readonly IMapper _mapper;
        private readonly IValidator<T> _validator;
        protected GenericController(IGenericService<T> service, IMapper mapper, IValidator<T> validator)
        {
            _mapper = mapper;
            _service = service;
            _validator = validator;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<T>>> GetAllAsync()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<T>> GetEmployeeByIdAsync([FromQuery] int id)
        {
            var entity = await _service.GetByIdAsync(id);
            var result = _mapper.Map<T>(entity);
            return Ok(result);
        }
        [HttpDelete("DeleteById")]
        public async Task<ActionResult<bool>> DeleteAsync([FromQuery] int id)
        {
            await _service.DeleteByIdAsync(id);
            return Ok();
        }

        [HttpPost("AddNew")]
        public async Task<ActionResult<T>> AddAsync([FromBody] T entity)
        {
            await _validator.ValidateAndThrowAsync(entity);
            var mapped = _mapper.Map<T>(entity);
            return Ok(await _service.AddAsync(mapped));
        }
        [HttpPut("Update")]
        public virtual async Task<ActionResult<T>> UpdateAsync([FromQuery] int id, [FromBody] T entity)
        {
            await _validator.ValidateAndThrowAsync(entity);
            var mapped = _mapper.Map<T>(entity);
            return Ok(await _service.UpdateAsync(mapped));
        }
    }
}
