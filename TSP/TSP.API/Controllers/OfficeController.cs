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
    [ApiController]
    [Route("[controller]")]
    public class OfficeController : ControllerBase
    {
          private readonly IOfficeService _service;
          private readonly IMapper _mapper;
          private readonly IValidator<OfficeAddViewModel> _validator;
          private readonly IValidator<OfficeViewModel> _validatorViewModel;
          public OfficeController(IOfficeService service, IMapper mapper, IValidator<OfficeAddViewModel> validator, IValidator<OfficeViewModel> validatorViewModel)
          {
              _service = service;
              _mapper = mapper;
              _validator = validator;
              _validatorViewModel = validatorViewModel;
          }

          [HttpGet("GetAllOffice")]
          public async Task<ActionResult<IEnumerable<OfficeViewModel>>> GetAllOficeAsync()
          {
              var office = await _service.GetAllAsync();
              var mapped = _mapper.Map<List<OfficeViewModel>>(office);
              return Ok(mapped);
          }

          [HttpGet("GetOfficeById")]
          public async Task<ActionResult<Office>> GetOfficeById(int id)
          {
              return Ok(_mapper.Map<OfficeViewModel>(await _service.GetByIdAsync(id)));
          }

          [HttpDelete("DeleteById")]
          public async Task<ActionResult<bool>> DeleteByIdAsync(int id)
          {
              await _service.DeleteByIdAsync(id);
              return Ok();
          }
          [HttpPost("AddOffice")]
          public async Task<ActionResult<Office>> AddOffice([FromBody] OfficeAddViewModel model)
          {
              await _validator.ValidateAndThrowAsync(model);
              var mapped = _mapper.Map<Office>(model);
              return Ok(await _service.AddAsync(mapped));
          }

          [HttpPut("UpdateOffice")]
          public async Task<ActionResult<Office>> UpdateOffice([FromQuery] int id, [FromBody] OfficeViewModel model)
          {
              await _validatorViewModel.ValidateAndThrowAsync(model);
              var mapped = _mapper.Map<Office>(model);
              mapped.Id = id;
              return Ok(await _service.UpdateAsync(mapped));
          }
    }
}