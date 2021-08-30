using Entities.Model;
using System.Collections.Generic;

namespace Contracts
{
    public interface IOfficeRepository
    {
        void Save();
        IEnumerable<Office> GetAll();
        Office GetById(int id);
        void RemoveById(int id);
        void Add(int id, string name, string address, string country);
        void Update(int id, string name, string address, string country);
    }
}
