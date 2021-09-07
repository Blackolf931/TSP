using AutoMapper;
using BLL.Models;
using TSP.API.ViewModels;

namespace TSP.API.AutoMapper
{
    public class ApiProfile : Profile
    {
        public ApiProfile()
        {
            CreateMap<Employee, EmployeeViewModel>().ReverseMap();
            CreateMap<EmployeeAddViewModel, Employee>();
            CreateMap<Office, OfficeViewModel>().ReverseMap();
            CreateMap<OfficeAddViewModel, Office>();
            CreateMap<EmployeeGetByIdViewModel, EmployeeGetById>().ReverseMap();
        }
    }
}
