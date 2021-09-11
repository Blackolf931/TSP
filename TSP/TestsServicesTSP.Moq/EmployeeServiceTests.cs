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
            _employeeRepoMock.Setup(x => x.GetByIdAsync(19)).ReturnsAsync(employeeEntity);
            
            //Act
            var employee = await _sut.GetEmployeeByIdAsync(19);

            //Assert
            Assert.Equal(employeeId, employee.Id);
        }
    }
}
