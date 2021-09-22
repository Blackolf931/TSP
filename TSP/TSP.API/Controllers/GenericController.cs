using AutoMapper;
using BLl.Interfaces;
using BLL.Services;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TSP.API.Controllers
{
    [ApiController]
    [Authorize]
    public class GenericController<T, TViewModel, TAddViewModel, TUpdateViewModel> : ControllerBase
        where T : IHasIdBase
    {
        private readonly IGenericService<T> _service;
        private readonly IMapper _mapper;
        private readonly IValidator<TAddViewModel> _validatorAddViewModel;
        private readonly IValidator<TUpdateViewModel> _validatorUpdateViewModel;
        protected GenericController(IGenericService<T> service, IMapper mapper, IValidator<TAddViewModel> validatorAddViewModel, IValidator<TUpdateViewModel> validatorUpdateViewModel)
        {
            _mapper = mapper;
            _service = service;
            _validatorAddViewModel = validatorAddViewModel;
            _validatorUpdateViewModel = validatorUpdateViewModel;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<T>>> GetAllAsync()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<ActionResult<T>> GetByIdAsync([FromQuery] int id)
        {
            var result = await _service.GetByIdAsync(id);
            return Ok(_mapper.Map<T>(result));
        }
        [HttpDelete("DeleteById")]
        public async Task<ActionResult<bool>> DeleteAsync([FromQuery] int id)
        {
            await _service.DeleteByIdAsync(id);
            return Ok();
        }
        [HttpPost("AddNew")]
        public async Task<ActionResult<T>> AddAsync([FromBody] TAddViewModel addViewModel)
        {
            await _validatorAddViewModel.ValidateAndThrowAsync(addViewModel);
            var mapped = _mapper.Map<T>(addViewModel);
            return Ok(await _service.AddAsync(mapped));
        }
        [HttpPut("Update/{id}")]
        public virtual async Task<ActionResult<T>> UpdateAsync(int id, [FromBody] TUpdateViewModel viewModel)
        {
            await _validatorUpdateViewModel.ValidateAndThrowAsync(viewModel);
            var mapped = _mapper.Map<T>(viewModel);
            mapped.Id = id;
            return Ok(await _service.UpdateAsync(mapped));
        }
    }
}