using DAL.Entities;
using System;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
      //  IRepository<Employee> Employes { get; }
        void Save();
    }
}
