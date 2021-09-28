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
            CreateMap<OfficeAddEntity, OfficeAddViewModel>().ReverseMap();
            CreateMap<CreateOfficeCommand, OfficeAddEntity>().ReverseMap();
            CreateMap<OfficeUpdateViewModel, Office>().ReverseMap();
            CreateMap<UpdateOfficeCommand, Office>().ReverseMap();
        }
    }
}