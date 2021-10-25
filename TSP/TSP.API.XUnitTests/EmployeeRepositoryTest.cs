using DAl.EF;
using DAL.Entities;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace TSP.API.XUnitTests
{
    public class EmployeeRepositoryTest
    {
        private readonly RepositoryContext _context = new
        (new DbContextOptionsBuilder<RepositoryContext>().UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options);

        private readonly EmployeeRepository _repo;

        public EmployeeRepositoryTest()
        {
            _repo = new EmployeeRepository(_context);
        }

        [Fact]
        public async Task GetSessions_ReturnsSessionList()
        {
            var id = new Random().Next();
            var employeeEntity = new EmployeeEntity()
            {
                Id = id,
                Name = "Test",
                SecondName = "Test",
                Patronomic = "Test",
                Age = 21,
                Position = "Test",
                OfficeId = 1
            };
            var officeEntity = new OfficeEntity()
            {
                Id = 1,
                Name = "Test",
                Address = "Test",
                Country = "Test"
            };
            await _context.Offices.AddAsync(officeEntity);
            await _context.Employees.AddAsync(employeeEntity);
            await _context.SaveChangesAsync();
            var employee = await _repo.FindAllAsync();

            Assert.IsType<List<EmployeeEntity>>(employee);
         //   Assert.NotEmpty(employee);
            Assert.NotNull(employee);
            await _context.Database.EnsureDeletedAsync();
        }

    }
}