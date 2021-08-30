using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        public IOfficeRepository _officeRepository;
        public IEmployeeRepository _employeeRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IOfficeRepository Office
        {
            get
            {
                if(_officeRepository is null)
                {
                    _officeRepository = new OfficeRepository(_repositoryContext);
                }
                return _officeRepository;
            }
        }

        public IEmployeeRepository Employee
        {
            get
            {
                if(_employeeRepository is null)
                {
                    _employeeRepository = new EmployeeRepository(_repositoryContext);
                }
                return _employeeRepository;
            }
        }

        public void Save() => _repositoryContext.SaveChanges();
    }
}
