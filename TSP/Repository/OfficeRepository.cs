using Contracts;
using Entities;
using Entities.Model;
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
        public void GetAll()
        {
            _repositoryContext.Offices.Any();
        }
        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
