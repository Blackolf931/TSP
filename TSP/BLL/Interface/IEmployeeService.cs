using BLL.DTO;
using System.Collections.Generic;

namespace BLL.Interface
{
    public interface IEmployeeService
    {
        void AddEmployee(EmployeeDTO employeeDto);
        EmployeeDTO GetEmployee(int? id);
        IEnumerable<EmployeeDTO> GetEmpoyes();
        void Dispose();
    }
}
