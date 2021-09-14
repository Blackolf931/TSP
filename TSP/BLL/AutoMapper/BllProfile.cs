using AutoMapper;
using BLL.Models;
using DAL.Entities;

namespace BLL.AutoMapper
{
    public class BllProfile : Profile
    {
        public BllProfile()
        {
            CreateMap<EmployeeEntity, Employee>().ReverseMap();
            CreateMap<OfficeEntity, Office>().ReverseMap();
        }
    }
}
