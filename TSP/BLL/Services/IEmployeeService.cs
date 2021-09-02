using BLL.Models;
using System.Collections.Generic;

namespace BLL.Services
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();
    }
}