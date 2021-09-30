using Application.CQRS.Commands;
using AutoMapper;
using Domain;
namespace Application.AutoMapper
{
    public class AppMapper : Profile
    {
        public AppMapper()
        {
            CreateMap<CreateOfficeCommand, Office>().ReverseMap();
            CreateMap<UpdateOfficeCommand, Office>().ReverseMap();
        }
    }
}