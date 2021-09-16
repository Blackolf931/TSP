using AutoMapper;
using BLL.Models;
using BLL.Services;
using DAL.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TSP.API.ViewModels;

namespace TSP.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OfficeController : GenericController<Office>
    {
        private readonly IMapper _mapper;
       // private readonly IValidator<Office> _validator;
        private readonly IGenericService<Office> _service;
        public OfficeController(IGenericService<Office> service, IMapper mapper) : base(service, mapper)
        {
            _mapper = mapper;
           // _validator = validator;
            _service = service;
        }

        [HttpPut("Update")]
        public override async Task<ActionResult<Office>> UpdateAsync([FromQuery] int id, [FromBody] Office entity)
        {
          //  await _validator.ValidateAndThrowAsync(_mapper.Map<Office>(entity));
            var mapped = _mapper.Map<Office>(entity);
            var result = await _service.UpdateAsync(mapped);
            return Ok(result);
        }
    }
}