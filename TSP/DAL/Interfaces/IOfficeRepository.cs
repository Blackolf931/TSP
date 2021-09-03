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
        Task<bool> DeleteByIdAsync(int id);
        Task<OfficeEntity> AddAsync(OfficeEntity entity);
        Task<OfficeEntity> UpdateAsync(OfficeEntity entity);
    }
}
