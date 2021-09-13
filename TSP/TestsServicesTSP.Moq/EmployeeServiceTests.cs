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

namespace TestsServicesTSP.Moq
{
    public class EmployeeServiceTests
    {
        private readonly EmployeeService _sut;
        private readonly Mock<IEmployeeRepository> _employeeRepoMock = new();
        private readonly IEnumerable<IStrategy> strategies = new List<IStrategy> { new MiddlePeopleSetAdditionalInfo(), new RetirePeopleSetadditionalInfo(), new YoungPeopleSetAdditionalInfo() };


        public EmployeeServiceTests()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new BllProfile());
            });
            var mapper = mockMapper.CreateMapper();
            _sut = new EmployeeService(_employeeRepoMock.Object, mapper, strategies);
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
            _employeeRepoMock.Setup(x => x.GetByIdAsync(employeeId)).ReturnsAsync(employeeEntity);

            //Act
            var employee = await _sut.GetEmployeeByIdAsync(employeeId);

            //Assert
            Assert.Equal(employeeId, employee.Id);
        }
        [Fact]
        public async Task GetEmployeeById_ShouldReturnNothing_WhereEmployeeDoesNotExists()
        {
            //Arange
            _employeeRepoMock.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(() => null);

            //Act
            var employee = await _sut.GetEmployeeByIdAsync(9999999);

            //Assert
            Assert.Null(employee);
        }
        [Fact]
        public async Task DeleteEmployeeById_ShouldBeReturnTrue_WhereEmployeeExists()
        {
            _employeeRepoMock.Setup(x => x.DeleteByIdAsync(19)).ReturnsAsync(() => true);
            var employee = await _sut.DeleteByIdAsync(19);
            Assert.True(employee);
        }
        [Fact]
        public async Task DeleteEmployeeById_ShouldBeReturnFalse_WhereEmployeeDoesNotExists()
        {
            _employeeRepoMock.Setup(x => x.DeleteByIdAsync(99999)).ReturnsAsync(() => false);
            var employee = await _sut.DeleteByIdAsync(999999);
            Assert.False(employee);
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
    }
}
