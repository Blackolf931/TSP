using AutoMapper;
using BLL.Models;
using BLL.Services;
using FluentValidation;
using TSP.API.ViewModels;

namespace TSP.API.Controllers
{
    public class EmployeeController : GenericController<Employee, EmployeeViewModel, EmployeeAddViewModel>
    {
        public EmployeeController(IEmployeeService service, IMapper mapper, IValidator<EmployeeAddViewModel> validatorAddViewModel, IValidator<EmployeeViewModel> validatorViewModel) : base(service, mapper, validatorViewModel, validatorAddViewModel)
        {
        }
    }
}