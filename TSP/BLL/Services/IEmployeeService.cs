using BLL.DTO;
using System.Collections.Generic;

namespace BLL.Services
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();
    }
}