using Application.CQRS.Commands;
using AutoMapper;
using Domain;

namespace Application.AutoMapper
{
    public class AppMapper : Profile
    {
        public AppMapper()
        {
            CreateMap<OfficeAddEntity, Office>().ReverseMap();
            CreateMap<CreateOfficeCommand, Office>().ReverseMap();
        }
    }
}