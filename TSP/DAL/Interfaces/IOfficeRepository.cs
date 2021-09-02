using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IOfficeRepository
    {
        void Save();
        Task<IEnumerable<OfficeEntity>> GetAllAsync();
        Task<OfficeEntity> GetByIdAsync(int id);
        Task RemoveByIdAsync(int id);
        Task Add(OfficeEntity entity);
        Task Update(OfficeEntity entity);
    }
}
