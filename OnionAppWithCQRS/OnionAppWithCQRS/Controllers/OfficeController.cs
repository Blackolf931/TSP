using Application.CQRS.Commands;
using Application.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace OnionAppWithCQRS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private IMediator mediator;
        public WeatherForecastController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOfficeCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new GetAllOfficeQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await mediator.Send(new GetOfficeByIdQuery { OfficeId = id }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await mediator.Send(new DeleteOfficeByIdCommand { Id = id }));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update(int id, UpdateOfficeCommand command)
        {
            if (id != command.OfficeId)
            {
                return BadRequest();
            }
            return Ok(await mediator.Send(command));
        }
    }
}