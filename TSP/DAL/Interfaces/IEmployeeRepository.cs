using DAL.Entities;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IEmployeeRepository
    {
        IEnumerable<EmployeeEntity> GetAll();
        EmployeeEntity GetById(int id);
        void DeleteById(int id);
        void Add(EmployeeEntity entity);

        void Update(EmployeeEntity entity);
    }
}
