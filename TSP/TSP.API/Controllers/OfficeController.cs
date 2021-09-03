using AutoMapper;
using BLL.Models;
using BLL.Services;
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


        public OfficeController(IOfficeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("GetAllOffice")]
        public async Task<ActionResult<IEnumerable<Office>>> GetAllOficeAsync()
        {
           return Ok(await _service.GetAllAsync());
        }

        [HttpGet("GetOfficeById")]
        public async Task<ActionResult<Office>> GetOfficeById(int id)
        {
            return Ok(_mapper.Map<OfficeViewModel>(await _service.GetByIdAsync(id)));
        }

        [HttpDelete("DeleteById")]
        public async Task<ActionResult<bool>> DeleteByIdAsync(int id)
        {
            if(await _service.DeleteByIdAsync(id) == true)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
            
        }
        [HttpPost("AddOffice")]
        public async Task<ActionResult<Employee>> AddOffice([FromBody]OfficeAddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return NoContent();
            }
            var mapped = _mapper.Map<Office>(model);
            return Ok(await _service.AddAsync(mapped));
        }

        [HttpPut("UpdateOffice")]
        public async Task<ActionResult<Office>> UpdateOffice([FromQuery] int id, [FromBody] OfficeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return NoContent();
            }
            var mapped = _mapper.Map<Office>(model);
            mapped.Id = id;
            return Ok(await _service.UpdateOfficeByAsync(mapped));
        }
    }
}
