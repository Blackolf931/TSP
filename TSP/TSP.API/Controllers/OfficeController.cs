﻿using Contracts;
using Entities.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TSP.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OfficeController : ControllerBase
    {
        private readonly IRepositoryManager _repository;

        public OfficeController(IRepositoryManager repository)
        {
            _repository = repository;
        }

        [HttpGet("GetAllOffice")]
        public ActionResult<IEnumerable<Employee>> Get()
        {
           return Ok(_repository.Office.GetAll());
        }

        [HttpGet("GetOfficeById")]
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
    }
}
