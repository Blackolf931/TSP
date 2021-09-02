using BLL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IOfficeService
    {
        Task<IEnumerable<Office>> GetAllAsync();
        Task<Office> GetByIdAsync(int id);
        Task RemoveByIdAsync(int id);
        Task AddAsync(Office office);
        Task UpdateOfficeByAsync(Office office);
    }
}