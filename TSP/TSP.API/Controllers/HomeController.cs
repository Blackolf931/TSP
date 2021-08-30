using Contracts;
using Entities.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TSP.API.ViewModels;

namespace TSP.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IRepositoryManager _repository;

        public HomeController(IRepositoryManager repository)
        {
            _repository = repository;
        }

        [HttpGet("GetAllOfficeAndEmployee")]
        public ActionResult<IEnumerable<string>> Get()
        {
          //   _repository.Office.AnyMethodFromOfficeRepository();
          //   _repository.Employee.AnyMethodFromEmployeeRepository();
         //   _repository.Office.Save();
            _repository.Office.GetAll();
            return new string[] { "value1", "value2" };
        }

    }

}

