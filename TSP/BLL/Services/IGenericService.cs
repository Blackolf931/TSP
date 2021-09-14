using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IGenericService<T, Tentity>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<bool> DeleteByIdAsync(int id);
        Task<T> AddAsync(T employee);
        Task<T> UpdateAsync(T employee);
    }
}