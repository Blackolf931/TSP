using AutoMapper;
using BLL.Models;
using BLL.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using TSP.API.ViewModels;

namespace TSP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OfficeController : GenericController<Office, OfficeViewModel, OfficeAddViewModel>
    {
        public OfficeController(IOfficeService service, IMapper mapper, IValidator<OfficeAddViewModel> validatorAddViewModel) : base(service, mapper, validatorAddViewModel)
        {
        }
    }
}