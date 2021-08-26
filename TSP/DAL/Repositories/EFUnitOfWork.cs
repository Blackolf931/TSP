using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private OfficeContext db;
        private OfficeRepository officeRepository;
        public EFUnitOfWork(string connectionString)
        {
            db = new OfficeContext(connectionString);
        }
        public IRepository<Employee> Employes
        {
            get
            {
                if (officeRepository == null)
                {
                    officeRepository = new OfficeRepository(db);
                }
                return officeRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
