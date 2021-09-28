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
            var result1 = _mapper.Map<CreateOfficeCommand>(res);
            var result = await _mediator.Send(result1);
            return Ok(_mapper.Map<OfficeAddViewModel>(result));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllOfficeQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetOfficeByIdQuery { OfficeId = id }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteOfficeByIdCommand { Id = id }));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromQuery] int id, OfficeUpdateViewModel officeUpdateViewModel)
        {
            var office = _mapper.Map<Office>(officeUpdateViewModel);
            office.OfficeId = id;
            var result = _mapper.Map<UpdateOfficeCommand>(office);
            return Ok(await _mediator.Send(result));
        }
    }
}