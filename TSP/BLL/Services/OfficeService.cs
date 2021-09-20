using AutoMapper;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class OfficeService : GenericService<Office, OfficeEntity>, IOfficeService
    {
        private readonly IOfficeRepository _repository;
        private readonly IMapper _mapper;
        public OfficeService(IOfficeRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public override async Task<IEnumerable<Office>> GetAllAsync()
        {
            var result = await _repository.FindAllAsync();
            return _mapper.Map<IEnumerable<Office>>(result);
        }
    }
}