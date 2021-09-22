using AutoMapper;
using BLL.Models;
using BLL.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using TSP.API.ViewModels;

namespace TSP.API.Controllers
{

    [Route("[controller]")]
    public class OfficeController : GenericController<Office, OfficeViewModel, OfficeAddViewModel, OfficeUpdateViewModel>
    {
        public OfficeController(IOfficeService service, IMapper mapper, IValidator<OfficeAddViewModel> validatorAddViewModel, IValidator<OfficeUpdateViewModel> validatorUpdateViewModel) : base(service, mapper, validatorAddViewModel, validatorUpdateViewModel)
        {
        }
    }
}