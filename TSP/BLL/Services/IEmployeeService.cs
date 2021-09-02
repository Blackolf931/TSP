using BLL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IEmployeeService
    {
       Task<IEnumerable<Employee>> GetAllAsync();
       Task<Employee> GetEmployeeByIdAsync(int id);
       Task DeleteByIdAsync(int id);
       Task AddAsync(Employee employee);
       Task UpdateAsync(Employee employee);
    }
}