using Contracts;
using Entities;
using Entities.DTO;
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
        private readonly RepositoryContext _repositoryContext;
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
          _repositoryContext.SaveChanges();
        }

        public void Add(int id, string name, string address, string country)
        {
            _repositoryContext.Offices.Add(new OfficeDto(id,name,address, country));
            _repositoryContext.SaveChanges();
        }

        public void Update(int id, string name, string address, string country)
        {
            _repositoryContext.Offices.Update(new OfficeDto(id, name, address, country));
            _repositoryContext.SaveChanges();
        }
    }
}
