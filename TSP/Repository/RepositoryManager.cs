using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
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
