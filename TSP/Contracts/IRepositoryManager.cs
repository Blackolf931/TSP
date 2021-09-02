

namespace Contracts
{
    public interface IRepositoryManager
    {
        IOfficeRepository Office { get; }
        IEmployeeRepository Employee { get; }
        void Save();
    }
}
