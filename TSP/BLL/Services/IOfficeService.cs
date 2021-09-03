using BLL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IOfficeService
    {
        Task<IEnumerable<Office>> GetAllAsync();
        Task<Office> GetByIdAsync(int id);
        Task<bool> RemoveByIdAsync(int id);
        Task<Office> AddAsync(Office office);
        Task<Office> UpdateOfficeByAsync(Office office);
    }
}