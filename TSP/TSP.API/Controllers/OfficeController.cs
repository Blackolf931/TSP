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
            var office = await _service.GetByIdAsync(id);
            var mappedOffice = _mapper.Map<OfficeViewModel>(office);
            return Ok(mappedOffice);
        }

        [HttpDelete("DeleteById")]
        public async Task<ActionResult<IEnumerable<string>>> DeleteByIdAsync(int id)
        {
            await _service.RemoveByIdAsync(id);
            return new string[] { "Office has been delete" };
        }
        [HttpPost("AddOffice")]
        public async Task<ActionResult> AddOffice(OfficeAddViewModel model)
        {
            var mapped = _mapper.Map<Office>(model);
            await _service.AddAsync(mapped);
            return Ok("You has been add office");
        }

        [HttpPost("UpdateOffice")]
        public async Task<ActionResult> UpdateOffice([FromQuery] int id, [FromBody] OfficeViewModel model)
        {
            var mapped = _mapper.Map<Office>(model);
            mapped.Id = id;
            await _service.UpdateOfficeByAsync(mapped);
            return Ok("You has been update office");
        }

    }
}
