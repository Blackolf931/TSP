﻿using BLL.Models;
using System.Text.RegularExpressions;

namespace BLL.Infastructure
{
    public class GenerateEmployeeException
    {
        public GenerateEmployeeException(Employee dto)
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
