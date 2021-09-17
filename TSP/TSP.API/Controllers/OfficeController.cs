using AutoMapper;
using BLL.Models;
using BLL.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using TSP.API.ViewModels;

namespace TSP.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OfficeController : GenericController<Office>
    {
        public OfficeController(IOfficeService service, IMapper mapper, IValidator<OfficeViewModel> validator) : base(service, mapper, (IValidator<Office>)validator)
        {
        }
    }
}