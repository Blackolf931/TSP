using Application.CQRS.Commands;
using AutoMapper;
using Domain;
using System.Threading.Tasks;

namespace Application.AutoMapper
{
    public class AppMapper : Profile
    {
        public AppMapper()
        {
            CreateMap<OfficeAddEntity, Office>().ReverseMap();
            CreateMap<OfficeCreateCommand, Office>().ReverseMap();
            CreateMap<OfficeUpdateCommand, Office>().ReverseMap();
        }
    }
}