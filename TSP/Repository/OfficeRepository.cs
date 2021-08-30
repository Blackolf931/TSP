using Contracts;
using Entities;
using Entities.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OfficeRepository : RepositoryBase<Office>, IOfficeRepository
    {
        private RepositoryContext _repositoryContext;
        public OfficeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public IEnumerable<Office> GetAll()
        {
            return _repositoryContext.Offices.Include(x => x.Employess).ToList();
        }
        public Office GetById(int id)
        {
             return _repositoryContext.Offices.Where(x => x.Id == id).FirstOrDefault();
        }
        public void Save()
        {
            throw new NotImplementedException();
        }
        public void RemoveById(int id)
        {
          _repositoryContext.Offices.Remove(_repositoryContext.Offices.Find(id));
        }
    }
}
