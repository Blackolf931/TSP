using AutoMapper;
using BLL.Models;
using DAL.Entities;

namespace BLL.AutoMapper
{
    public class BllProfile : Profile
    {
        public BllProfile()
        {
            CreateMap<EmployeeEntity, Employee>();
            CreateMap<Employee, EmployeeEntity>();
            CreateMap<OfficeEntity, Office>();
            CreateMap<Office, OfficeEntity>();
        }
    }
}
