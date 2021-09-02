using BLL.Models;
using DAL.Interfaces;
using System.Collections.Generic;

namespace BLL.Services
{
    public class OfficeService : IOfficeService
    {
        private readonly IOfficeRepository _repository;

        public OfficeService(IOfficeRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<Office> GetAll()
        {
            List<Office> officesList = new();
            var offices = _repository.GetAll();
            foreach (var el in offices)
            {
                var employeeList = new List<Employee>();
                foreach(var employee in el.Employess) {
                    
                    employeeList.Add(new Employee { Id = employee.Id, Name = employee.Name, SecondName = employee.SecondName, Patronomic = employee.Patronomic, Age = employee.Age, Position = employee.Position }); 
                }
                officesList.Add(new Office
                {
                    Id = el.Id,
                    Name = el.Name,
                    Address = el.Address,
                    Country = el.Country,
                    Employess = employeeList,
                }) ;
            }
            return officesList;
        }
    }
}
