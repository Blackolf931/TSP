using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeEntity>> GetAllAsync();
        Task<EmployeeEntity> GetByIdAsync(int id);
        Task<bool> DeleteByIdAsync(int id);
        Task<EmployeeEntity> AddAsync(EmployeeEntity entity);
        Task<EmployeeEntity> UpdateAsync(EmployeeEntity entity);
    }
}
