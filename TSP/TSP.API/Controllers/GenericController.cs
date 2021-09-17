using AutoMapper;
using BLL.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TSP.API.Interfaces;

namespace TSP.API.Controllers
{
    [ApiController]
    public class GenericController<T, TViewModel, TAddViewModel> : ControllerBase
        where TViewModel : IHasIdBase
    {
        private readonly IGenericService<T> _service;
        private readonly IMapper _mapper;
        private readonly IValidator<TViewModel> _validatorViewModel;
        private readonly IValidator<TAddViewModel> _validatorAddViewModel;
        protected GenericController(IGenericService<T> service, IMapper mapper, IValidator<TViewModel> validatorViewModel, IValidator<TAddViewModel> validatorAddViewModel)
        {
            _mapper = mapper;
            _service = service;
            _validatorViewModel = validatorViewModel;
            _validatorAddViewModel = validatorAddViewModel;
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
        public virtual async Task<ActionResult<T>> UpdateAsync(int id, [FromBody] TViewModel viewModel)
        {
            await _validatorViewModel.ValidateAndThrowAsync(viewModel);
            viewModel.Id = id;
            var mapped = _mapper.Map<T>(viewModel);
            return Ok(await _service.UpdateAsync(mapped));
        }
    }
}