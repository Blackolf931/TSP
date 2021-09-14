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
        private readonly IRepositoryBase<OfficeEntity> _repository;
        private readonly IMapper _mapper;

        public OfficeService(IRepositoryBase<OfficeEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Office>> GetAllAsync()
        {
            var office = await _repository.FindAllAsync();
            return _mapper.Map<IEnumerable<Office>>(office);
        }

        public async Task<Office> GetByIdAsync(int id)
        {
            var office = await _repository.FindByIdAsync(id);
            var mappedOffice = _mapper.Map<Office>(office);
            return mappedOffice;
        }
        public async Task<bool> DeleteByIdAsync(int id)
        {
            var office = _repository.FindByIdAsync(id);
            if (office is null)
            {
                return false;
            }
            else
            {
                var mapped = _mapper.Map<OfficeEntity>(office);
                await _repository.DeleteByIdAsync(mapped);
                return true;
            }
        }
        public async Task<Office> AddAsync(Office office)
        {
            var mappedOffice = _mapper.Map<OfficeEntity>(office);
            return _mapper.Map<Office>(await _repository.AddAsync(mappedOffice));
        }
        public async Task<Office> UpdateOfficeByAsync(Office office)
        {
            var mappedOffice = _mapper.Map<OfficeEntity>(office);
            var updatedOffice = await _repository.UpdateAsync(mappedOffice);
            return _mapper.Map<Office>(updatedOffice);
        }
    }
}
