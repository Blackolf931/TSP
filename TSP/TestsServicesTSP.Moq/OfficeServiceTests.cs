using AutoMapper;
using BLL.AutoMapper;
using BLL.Models;
using BLL.Services;
using DAL.Entities;
using DAL.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestsServicesTSP.Moq
{
    public class OfficeServiceTests
    {
        private readonly OfficeService _ost;
        private readonly Mock<IOfficeRepository> _officeRepoMock = new();

        public OfficeServiceTests()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new BllProfile());
            });
            var mapper = mockMapper.CreateMapper();
            _ost = new OfficeService(_officeRepoMock.Object, mapper);
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
            _officeRepoMock.Setup(x => x.GetByIdAsync(officeId)).ReturnsAsync(officeEntity);

            //Act
            var office = await _ost.GetByIdAsync(officeId);

            //Assert
            Assert.Equal(officeId, office.Id);
        }

        [Fact]
        public async Task GetEOfficeById_ShouldReturnNothing_WhereOfficeDoesNotExists()
        {
            //Arange
            var officeId = new Random().Next(1, 20);

            _officeRepoMock.Setup(x => x.GetByIdAsync(officeId)).ReturnsAsync(() => null);

            //Act
            var office = await _ost.GetByIdAsync(officeId);

            //Assert
            Assert.Null(office);
        }
        [Fact]
        public async Task DeleteOfficeById_ShouldBeReturnTrue_WhereOfficeeExists()
        {
            _officeRepoMock.Setup(x => x.DeleteByIdAsync(2)).ReturnsAsync(() => true);
            var employee = await _ost.DeleteByIdAsync(2);
            Assert.True(employee);
        }
        [Fact]
        public async Task DeleteOfficeById_ShouldBeReturnFalse_WhereOfficeDoesNotExists()
        {
            _officeRepoMock.Setup(x => x.DeleteByIdAsync(99999)).ReturnsAsync(() => false);
            var employee = await _ost.DeleteByIdAsync(999999);
            Assert.False(employee);
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
            _officeRepoMock.Setup(x => x.UpdateAsync(officeEntity)).ReturnsAsync(officeEntity);
            var office = await _ost.UpdateOfficeByAsync(new Office { Id = 2, Name = "Test", Address = "Test", Country = "Test" });
            Assert.Equal(2, office.Id);
        }
    }
}
