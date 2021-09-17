using AutoMapper;
using BLL.Interfaces;
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
        public OfficeController(IOfficeService service, IMapper mapper, IValidator<OfficeViewModel> validatorViewModel, IValidator<OfficeAddViewModel> validatorAddViewModel, IOfficeSetId setId) : base(service, mapper, validatorViewModel, validatorAddViewModel, setId)
        {
        }
    }
}