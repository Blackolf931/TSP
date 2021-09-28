using Application.CQRS.Commands;
using Application.CQRS.Queries;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnionAppWithCQRS.ViewModels;
using System.Threading.Tasks;

namespace OnionAppWithCQRS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OfficeController : ControllerBase
    {
        private IMediator _mediator;
        private readonly IMapper _mapper;
        public OfficeController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(OfficeAddViewModel officeAddView)
        {
            var res = _mapper.Map<OfficeAddEntity>(officeAddView);
            var result1 = _mapper.Map<OfficeCreateCommand>(res);
            var result = await _mediator.Send(result1);
            return Ok(_mapper.Map<OfficeAddViewModel>(result));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new OfficeGetAllQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _mediator.Send(new OfficeGetByIdQuery { OfficeId = id }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) => await _mediator.Send(new OfficeDeleteByIdCommand { Id = id }) == true ? Ok() : BadRequest();

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromQuery] int id, OfficeUpdateViewModel officeUpdateViewModel)
        {
            var result = _mapper.Map<OfficeUpdateCommand>(officeUpdateViewModel);
            result.Id = id;
            return Ok(await _mediator.Send(result));
        }
    }
}