using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeEntity>> GetAllAsync();
        Task<EmployeeEntity> GetByIdAsync(int id);
        Task DeleteByIdAsync(int id);
        Task Add(EmployeeEntity entity);
        Task UpdateAsync(EmployeeEntity entity);
    }
}
