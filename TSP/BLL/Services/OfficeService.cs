using AutoMapper;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class OfficeService : GenericService<Office, OfficeEntity>, IOfficeService
    {
        public IRepositoryBase<OfficeEntity> _repository;
        public IMapper _mapper;

        public OfficeService(IRepositoryBase<OfficeEntity> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
