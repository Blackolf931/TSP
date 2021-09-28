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
            CreateMap<OfficeCreateCommand, OfficeAddEntity>().ReverseMap();
            CreateMap<OfficeUpdateViewModel, OfficeUpdateCommand>().ReverseMap();
            CreateMap<OfficeUpdateCommand, Office>().ReverseMap();
        }
    }
}