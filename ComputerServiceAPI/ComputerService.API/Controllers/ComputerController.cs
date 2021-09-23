using Microsoft.AspNetCore.Mvc;

namespace ComputerService.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComputerController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "GetAll";
        }
        [HttpDelete("Delete")]
        public ActionResult<bool> Delete()
        {
            return Ok(true);
        }
        [HttpPost("Add")]
        public ActionResult<string> Add()
        {
            return "Computer was been add";
        }
        [HttpPut("Update")]
        public ActionResult<string> Update()
        {
            return "Computer was updated";
        }
    }
}