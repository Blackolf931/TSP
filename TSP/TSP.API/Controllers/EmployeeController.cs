using AutoMapper;
using BLL.Models;
using BLL.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using TSP.API.ViewModels;

namespace TSP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : GenericController<Employee, EmployeeViewModel, EmployeeAddViewModel>
    {
        public EmployeeController(IEmployeeService service, IMapper mapper, IValidator<EmployeeAddViewModel> validatorAddViewModel) : base(service, mapper, validatorAddViewModel)
        {
        }
    }
}
