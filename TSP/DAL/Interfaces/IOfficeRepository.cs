using DAL.Entities;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IOfficeRepository
    {
        void Save();
        IEnumerable<OfficeEntity> GetAll();
        OfficeEntity GetById(int id);
        void RemoveById(int id);
        void Add(OfficeEntity entity);
        void Update(OfficeEntity entity);
    }
}
