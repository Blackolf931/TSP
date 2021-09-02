using DAl.BusinessLogic;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.BusinessLogic
{
    public class OfficeRepository : RepositoryBase<OfficeEntity>, IOfficeRepository
    {
        private readonly RepositoryContext _repositoryContext;
        public OfficeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public IEnumerable<OfficeEntity> GetAll()
        {
            return _repositoryContext.Offices.Include(x => x.Employess).ToList();
        }
        public OfficeEntity GetById(int id)
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

        public void Add(OfficeEntity entity)
        {
            _repositoryContext.Offices.Add(entity);
            _repositoryContext.SaveChanges();
        }

        public new void Update(OfficeEntity entity)
        {
            _repositoryContext.Offices.Update(entity);
            _repositoryContext.SaveChanges();
        }
    }
}
