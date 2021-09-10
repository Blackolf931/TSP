using AutoMapper;
using BLL.Infastructure;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class OfficeService : IOfficeService
    {
        private readonly IOfficeRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<OfficeService> _logger;

        public OfficeService(IOfficeRepository repository, IMapper mapper, ILogger<OfficeService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<IEnumerable<Office>> GetAllAsync()
        {
            var office = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<Office>>(office);
        }

        public async Task<Office> GetByIdAsync(int id)
        {
            try
            {
                var office = await _repository.GetByIdAsync(id);
                var mappedOffice = _mapper.Map<Office>(office);
                return mappedOffice;
            }
            catch(Exception ex)
            {
                _logger.LogInformation(ex, "Office not found");
                throw new OfficeException("Office not found");
            }
        }
        public Task<bool> DeleteByIdAsync(int id)
        {
            try
            {
                return _repository.DeleteByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, "The Office has not been deleted");
                throw new OfficeException("The Office has not been deleted");
            }
        }
        public async Task<Office> AddAsync(Office office)
        {
            try
            {
                var mappedOffice = _mapper.Map<OfficeEntity>(office);
                return _mapper.Map<Office>(await _repository.AddAsync(mappedOffice));
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, "The office has not been added");
                throw new OfficeException("The office has not been added");
            }
        }
        public async Task<Office> UpdateOfficeByAsync(Office office)
        {
            try
            {
                var mappedOffice = _mapper.Map<OfficeEntity>(office);
                return _mapper.Map<Office>(await _repository.UpdateAsync(mappedOffice));
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, "The office has not been added");
                throw new OfficeException("The office has not been updated");
            }
        }
    }
}
