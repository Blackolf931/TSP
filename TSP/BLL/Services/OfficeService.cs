using AutoMapper;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class OfficeService : GenericService<Office, OfficeEntity>, IOfficeService
    {
        public OfficeService(IRepositoryBase<OfficeEntity> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
