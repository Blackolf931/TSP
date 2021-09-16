using AutoMapper;
using BLL.AutoMapper;
using BLL.Models;
using BLL.Services;
using DAL.Entities;
using DAL.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace TSP.API.XUnitTests
{

    public class EmployeeServiceTests
    {
        private readonly IEmployeeService _sut;
        private readonly Mock<IRepositoryBase<EmployeeEntity>> _employeeRepoMock = new();
        private readonly IEnumerable<IStrategy> strategies = new List<IStrategy> { new MiddlePeopleSetAdditionalInfoStrategy(), new RetirePeopleSetadditionalInfoStrategy(), new YoungPeopleSetAdditionalInfoStrategy() };
        private readonly IMapper _mapper;

        public EmployeeServiceTests()
        {
            var mockMapper = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new BllProfile());
                });
            _mapper = mockMapper.CreateMapper();
            _sut = new EmployeeService(_employeeRepoMock.Object, _mapper, strategies);
        }

        [Fact]
        public async Task GetEmployeeById_ShouldReturnEmployee_WhereEmployeeExists()
        {
            //Arange
            var employeeId = new Random().Next(1, 20);
            var employeeEntity = new EmployeeEntity
            {
                Id = employeeId,
                Name = "Test",
                SecondName = "Test",
                Patronomic = "Test",
                Age = 25,
                Position = "Test",
                OfficeId = 2
            };
            _employeeRepoMock.Setup(x => x.FindByIdAsync(employeeId)).ReturnsAsync(employeeEntity);

            //Act
            var employee = await _sut.GetByIdAsync(employeeId);
            //Assert
            Assert.Equal(employeeId, employee.Id);
        }
        [Fact]
        public async Task GetEmployeeById_ShouldReturnNothing_WhereEmployeeDoesNotExists()
        {
            //Arange
            _employeeRepoMock.Setup(x => x.FindByIdAsync(It.IsAny<int>())).ReturnsAsync(() => null);

            //Act
            var employee = await _sut.GetByIdAsync(9999999);

            //Assert
            Assert.Null(employee);
        }
        [Fact]
        public async Task DeleteEmployeeById_ShouldBeReturnTrue_WhereEmployeeExists()
        {
            var employeeId = new Random().Next(1, 20);
            var employeeEntity = new EmployeeEntity
            {
                Id = employeeId,
                Name = "Test",
                SecondName = "Test",
                Patronomic = "Test",
                Age = 25,
                Position = "Test",
                OfficeId = 2
            };
            _employeeRepoMock.Setup(x => x.FindByIdAsync(employeeId)).ReturnsAsync(employeeEntity);
            var result = await _sut.DeleteByIdAsync(employeeId);
            Assert.True(result);
        }
        [Fact]
        public async Task DeleteEmployeeById_ShouldBeReturnFalse_WhereEmployeeDoesNotExists()
        {
            var result = await _sut.DeleteByIdAsync(int.MaxValue);
            Assert.False(result);
        }
        [Fact]
        public async Task UpdateEmployee_shouldBeReturnEmployee()
        {
            var employeeEntity = new EmployeeEntity
            {
                Id = 2,
                Name = "Test",
                SecondName = "Test",
                Patronomic = "Test",
                Age = 25,
                Position = "Test",
                OfficeId = 2
            };
            var employee = new Employee
            {
                Id = 2,
                Name = "Test",
                SecondName = "Test",
                Patronomic = "Test",
                Age = 25,
                Position = "Test",
                OfficeId = 2
            };
            _employeeRepoMock.Setup(x => x.UpdateAsync(It.IsAny<EmployeeEntity>())).ReturnsAsync(employeeEntity);
            var updateEmployee = await _sut.UpdateAsync(employee);
            Assert.Equal(employee.Id, updateEmployee.Id);
        }
        [Fact]
        public async Task GetEmployeeById_ShouldReturnAdditionalInfo_WhereEmployeeHaveMiddleAge()
        {
            //Arange
            var employeeId = new Random().Next(1, 20);
            var employeeEntity = new EmployeeEntity
            {
                Id = employeeId,
                Name = "Test",
                SecondName = "Test",
                Patronomic = "Test",
                Age = 25,
                Position = "Test",
                OfficeId = 2
            };
            _employeeRepoMock.Setup(x => x.FindByIdAsync(employeeId)).ReturnsAsync(employeeEntity);

            //Act
            var employee = await _sut.GetByIdAsync(employeeId);

            //Assert
            Assert.Equal("Your are middle people", employee.AdditionalInformation);
        }
        [Fact]
        public async Task GetEmployeeById_ShouldReturnAdditionalInfo_WhereEmployeeUnderEighteen()
        {
            //Arange
            var employeeId = new Random().Next(1, 20);
            var employeeEntity = new EmployeeEntity
            {
                Id = employeeId,
                Name = "Test",
                SecondName = "Test",
                Patronomic = "Test",
                Age = 17,
                Position = "Test",
                OfficeId = 2
            };
            _employeeRepoMock.Setup(x => x.FindByIdAsync(employeeId)).ReturnsAsync(employeeEntity);

            //Act
            var employee = await _sut.GetByIdAsync(employeeId);

            //Assert
            Assert.Equal("Your are young people", employee.AdditionalInformation);
        }
        [Fact]
        public async Task GetEmployeeById_ShouldReturnAdditionalInfo_WhereEmployeeUnderSixty()
        {
            //Arange
            var employeeId = new Random().Next(1, 20);
            var employeeEntity = new EmployeeEntity
            {
                Id = employeeId,
                Name = "Test",
                SecondName = "Test",
                Patronomic = "Test",
                Age = 61,
                Position = "Test",
                OfficeId = 2
            };
            _employeeRepoMock.Setup(x => x.FindByIdAsync(employeeId)).ReturnsAsync(employeeEntity);

            //Act
            var employee = await _sut.GetByIdAsync(employeeId);

            //Assert
            Assert.Equal("Your are retire", employee.AdditionalInformation);
        }
    }
}