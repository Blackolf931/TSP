
using BLL.Models;
using BLL.Services;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TSP.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OfficeController : ControllerBase
    {
        private readonly IOfficeService _service;


        public OfficeController(IOfficeService service)
        {
            _service = service;
        }

        [HttpGet("GetAllOffice")]
        public ActionResult<IEnumerable<Office>> GetAllOfice()
        {
           return Ok(_service.GetAll());
        }

      /*  [HttpGet("GetOfficeById")]
        public ActionResult<Office> GetOfficeById(int id)
        {
           return _repository.Office.GetById(id);
        }

        [HttpDelete("DeleteById")]
        public ActionResult<IEnumerable<string>> Delete(int id)
        {
            _repository.Office.RemoveById(id);
            return new string[] { "Office has been delete" };
        }
        [HttpPost("AddOffice")]
        public ActionResult AddOffice(int id, string name, string address, string country)
        {
            ValidData(new OfficeDto(id, name, address, country));
            _repository.Office.Add(id, name, address, country);
            return Ok("You has been add office");
        }

        [HttpPost("UpdateOffice")]
        public ActionResult UpdateOffice(int id, string name, string address, string country)
        {
            ValidData(new OfficeDto(id, name, address, country));
            _repository.Office.Update(id, name, address, country);
            return Ok("You has been update office");
        }

        private static void ValidData(OfficeDto dto)
        {
            _ = new GenerateOfficeException(dto);
        }*/
    }
}
