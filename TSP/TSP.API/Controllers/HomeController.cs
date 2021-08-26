using AutoMapper;
using BLL_1.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TSP.API.ViewModels;

namespace TSP.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        [HttpGet("GetAllEmployee")]
        public ActionResult GetEmployee()
        {
            List<EmployeeViewModel> employess;
            using(OfficeContext db = new OfficeContext())
            {
                employess = db.Employess.ToArray().Select(x => new EmployeeViewModel(x)).ToList();
            }
            return Ok(employess);
        }

        [HttpPost("AddEmployee")]
        public ActionResult AddEmployee(EmployeeViewModel employee)
        {
            using(OfficeContext db = new OfficeContext())
            {
                EmployeeDTO dto = new EmployeeDTO();
                dto.Name = employee.Name;
                dto.SecondName = employee.SecondName;
                dto.Age = employee.Age;
                dto.Id = employee.Id;
                db.Employess.Add(dto);
                db.SaveChanges();
            }
            return Ok();
        }

    }

}

