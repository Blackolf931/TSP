using Contracts;
using Entities.DTO;
using Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TSP.API.Exceptions
{
    public class GenerateEmployeeException
    {
        public GenerateEmployeeException(EmployeeDto dto)
        {
            CheckData(dto.Id);
            CheckData(dto.Name);
            CheckData(dto.Patronomic);
            CheckData(dto.Age);
            CheckData(dto.Position);
        }

        public void CheckData(int id)
        {
            if (id <= 0)
                throw new EmployeeException("Id cannot be less or equals zero");
        }
        public void CheckData(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                throw new EmployeeException("String cannot be less or equals null");

            Regex r = new(@"[\d!#h]");
            if (r.IsMatch(str))
            {
                throw new EmployeeException("String have wrong symbols");
            }
        }
    }
}
