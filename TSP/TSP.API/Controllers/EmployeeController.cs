using AutoMapper;
using BLL.Models;
using BLL.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using TSP.API.ViewModels;

namespace TSP.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : GenericController<Employee, EmployeeViewModel, EmployeeAddViewModel, EmployeeUpdateViewModel>
    {
        public EmployeeController(IEmployeeService service, IMapper mapper, IValidator<EmployeeAddViewModel> validatorAddViewModel, IValidator<EmployeeUpdateViewModel> validatorUpdateViewModel) : base(service, mapper, validatorAddViewModel, validatorUpdateViewModel)
        {
        }
    }
}