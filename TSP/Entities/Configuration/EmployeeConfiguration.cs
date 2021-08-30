using Entities.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Entities.Configuration
{
    class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData(
           new Employee { Id = 1, Name = "Sam", SecondName = "Raiden", Patronomic = "Olovson", Age = 26, Position = "Software developer",
                OfficeId = 1 },
           new Employee { Id = 2, Name = "Tom", SecondName = "Potter", Patronomic = "Olovson", Age = 26, Position = "Junior",
             OfficeId = 2}
        );
        }
    }
}
