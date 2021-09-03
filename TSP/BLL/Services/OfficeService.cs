﻿using AutoMapper;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class OfficeService : IOfficeService
    {
        private readonly IOfficeRepository _repository;
        private readonly IMapper _mapper;

        public OfficeService(IOfficeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Office>> GetAllAsync()
        {
            var office = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<Office>>(office);
        }

        public async Task<Office> GetByIdAsync(int id)
        {
            var office = await _repository.GetByIdAsync(id);
            var mappedOffice = _mapper.Map<Office>(office);
            return mappedOffice;

        }
        public async Task<bool> RemoveByIdAsync(int id) => await _repository.DeleteByIdAsync(id);

        public async Task<Office> AddAsync(Office office)
        {
            var mappedOffice = _mapper.Map<OfficeEntity>(office);
            return _mapper.Map<Office>(await _repository.AddAsync(mappedOffice));
        }
        public async Task<Office> UpdateOfficeByAsync(Office office)
        {
            var mappedOffice = _mapper.Map<OfficeEntity>(office);
            return _mapper.Map<Office>(await _repository.UpdateAsync(mappedOffice));
        }
    }
}
