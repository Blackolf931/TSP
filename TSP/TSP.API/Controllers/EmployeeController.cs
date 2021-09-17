using AutoMapper;
using BLL.Models;
using BLL.Services;
using FluentValidation;

namespace TSP.API.Controllers
{
    public class EmployeeController : GenericController<Employee>
    {
        public EmployeeController(IEmployeeService service, IMapper mapper, IValidator<Employee> validator) : base(service, mapper, validator)
        {

        }
    }
}