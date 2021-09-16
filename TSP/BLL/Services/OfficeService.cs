using AutoMapper;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class OfficeService : GenericService<OfficeEntity>, IOfficeService
    {
        public OfficeService(IRepositoryBase<OfficeEntity> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
