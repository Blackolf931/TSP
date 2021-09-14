using AutoMapper;
using BLL.AutoMapper;
using BLL.Models;
using BLL.Services;
using DAL.Entities;
using DAL.Interfaces;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace TestsServicesTSP.Moq
{
    public class OfficeServiceTests
    {
        private readonly GenericService<Office, OfficeEntity> _ost;
        private readonly Mock<IRepositoryBase<OfficeEntity>> _officeRepoMock = new();
        private readonly IMapper _mapper;

        public OfficeServiceTests()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new BllProfile());
            });
            _mapper = mockMapper.CreateMapper();
            _ost = new GenericService<Office, OfficeEntity>(_officeRepoMock.Object, _mapper);
        }

        [Fact]
        public async Task GetOfficeById_ShouldReturnOffice_WhereOfficeExists()
        {
            //Arange
            var officeId = new Random().Next(1, 20);
            var officeEntity = new OfficeEntity
            {
                Id = officeId,
                Name = "Test",
                Address = "Test",
                Country = "Test",
            };
            _officeRepoMock.Setup(x => x.FindByIdAsync(officeId)).ReturnsAsync(officeEntity);

            //Act
            var office = await _ost.GetByIdAsync(officeId);

            //Assert
            Assert.Equal(officeId, office.Id);
        }

        [Fact]
        public async Task GetOfficeById_ShouldReturnNothing_WhereOfficeDoesNotExists()
        {
            //Arange
            var officeId = new Random().Next(1, 20);

            _officeRepoMock.Setup(x => x.FindByIdAsync(officeId)).ReturnsAsync(() => null);

            //Act
            var office = await _ost.GetByIdAsync(officeId);

            //Assert
            Assert.Null(office);
        }
        [Fact]
        public async Task DeleteOfficeById_ShouldBeReturnTrue_WhereOfficeeExists()
        {
            var officeId = new Random().Next(1, 20);
            var officeEntity = new OfficeEntity
            {
                Id = officeId,
                Name = "Test",
                Address = "Test",
                Country = "Test",
            };
            _officeRepoMock.Setup(x => x.FindByIdAsync(officeId)).ReturnsAsync(officeEntity);
            var office = await _ost.GetByIdAsync(officeId);
            var mapped =  _mapper.Map<OfficeEntity>(office);
            _officeRepoMock.Setup(x => x.DeleteByIdAsync(mapped));
            var result = await _ost.DeleteByIdAsync(officeId);
            Assert.True(result);
        }
        [Fact]
        public async Task DeleteOfficeById_ShouldBeReturnFalse_WhereOfficeDoesNotExists()
        {
            var result = await _ost.DeleteByIdAsync(int.MaxValue);
            Assert.False(result);
        }
        [Fact]
        public async Task UpdateOffice_shouldBeReturnOffice()
        {
            var officeEntity = new OfficeEntity
            {
                Id = 2,
                Name = "Test",
                Address = "Test",
                Country = "Test"
            };
            var offices = new Office
            {
                Id = 2,
                Name = "Test",
                Address = "Test",
                Country = "Test"
            };
            _officeRepoMock.Setup(x => x.UpdateAsync(It.IsAny<OfficeEntity>())).ReturnsAsync(officeEntity);
            var office = await _ost.UpdateAsync(offices);
            Assert.Equal(2, office.Id);
        }
    }
}
