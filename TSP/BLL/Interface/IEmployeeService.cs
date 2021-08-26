using BLL_1.DTO;
using System.Collections.Generic;

namespace BLL_1.Interface
{
    public interface IEmployeeService
    {
        void AddEmployee(EmployeeDTO employeeDto);
        EmployeeDTO GetEmployee(int? id);
        IEnumerable<EmployeeDTO> GetEmpoyes();
        void Dispose();
    }
}
