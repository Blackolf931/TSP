using Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int id);
        void DeleteById(int id);
        void Add(int id, string name, string secondName, string patronomic, int age, string position, int officeId);

        void Update(int id, string name, string secondName, string patronomic, int age, string position, int officeId);
    }
}
