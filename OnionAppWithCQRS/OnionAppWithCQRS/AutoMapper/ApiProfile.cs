using Application.CQRS.Commands;
using AutoMapper;
using Domain;
using OnionAppWithCQRS.ViewModels;

namespace OnionAppWithCQRS.AutoMapper
{
    public class ApiProfile : Profile
    {
        public ApiProfile()
        {
            CreateMap<CreateOfficeCommand, OfficeAddViewModel >().ReverseMap();
            CreateMap<CreateOfficeCommand, OfficeAddModel>().ReverseMap();
            CreateMap<OfficeUpdateViewModel, UpdateOfficeCommand>().ReverseMap();
        }
    }
}