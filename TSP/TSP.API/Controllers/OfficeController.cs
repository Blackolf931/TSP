using AutoMapper;
using BLL.Models;
using BLL.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TSP.API.Validators;
using TSP.API.ViewModels;

namespace TSP.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OfficeController : ControllerBase
    {
        private readonly IOfficeService _service;
        private readonly IMapper _mapper;
        private readonly IValidator<OfficeAddViewModel> _validator;
        private readonly IValidator<OfficeViewModel> _validatorViewModel;
        private readonly ILogger<OfficeController> _logger;


        public OfficeController(IOfficeService service, IMapper mapper, IValidator<OfficeAddViewModel> validator, IValidator<OfficeViewModel> validatorViewModel, ILogger<OfficeController> logger)
        {
            _service = service;
            _mapper = mapper;
            _validator = validator;
            _validatorViewModel = validatorViewModel;
            _logger = logger;
        }

        [HttpGet("GetAllOffice")]
        public async Task<ActionResult<IEnumerable<Office>>> GetAllOficeAsync()
        {
                return Ok(await _service.GetAllAsync());
        }

        [HttpGet("GetOfficeById")]
        public async Task<ActionResult<Office>> GetOfficeById(int id)
        {
            try 
            {
                return Ok(_mapper.Map<OfficeViewModel>(await _service.GetByIdAsync(id)));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Get office error");
                return NoContent();
            }
        }

        [HttpDelete("DeleteById")]
        public async Task<ActionResult<bool>> DeleteByIdAsync(int id)
        {
            try
            {
                await _service.DeleteByIdAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, "Delete Error");
                return NotFound();
            }
            
        }
        [HttpPost("AddOffice")]
        public async Task<ActionResult<Employee>> AddOffice([FromBody] OfficeAddViewModel model)
        {
            try
            {
                await _validator.ValidateAndThrowAsync(model);
                var mapped = _mapper.Map<Office>(model);
                return Ok(await _service.AddAsync(mapped));
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, "Add Error");
                return NoContent();
            }
        }

        [HttpPut("UpdateOffice")]
        public async Task<ActionResult<Office>> UpdateOffice([FromQuery] int id, [FromBody] OfficeViewModel model)
        {
            try
            {
                await _validatorViewModel.ValidateAndThrowAsync(model);
                var mapped = _mapper.Map<Office>(model);
                mapped.Id = id;
                return Ok(await _service.UpdateOfficeByAsync(mapped));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Update error");
                return NoContent();
            }
        }
    }
}
