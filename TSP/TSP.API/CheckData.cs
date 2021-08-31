using Contracts;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TSP.API.Exceptions;

namespace TSP.API
{
    public class CheckData
    {
        public void CheckId(int id)
        {
            if (id <= 0)
                throw new EmployeeException("Id cannot be less or equals zero");
        }
        public void CheckStringOnValid(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                throw new EmployeeException("String cannot be less or equals null");

            Regex r = new(@"[\d!#h]");
            if (r.IsMatch(str))
            {
                throw new EmployeeException("String have wrong symbols");
            }
        }
        public void CheckOfficeId(int id, IRepositoryManager repositoryManager)
        {
            if (repositoryManager.Office.GetById(id) is null)
            {
                throw new EmployeeException("Office does not exist");
            }
        }
        public void CheckAge(int age)
        {
            if (age <= 0 || age < 18)
            {
                throw new EmployeeException("Age cannot be less zero or eighteen");
            }
            if (age > 70)
            {
                throw new EmployeeException("Please cheak age");
            }
        }
        public void CheckEmployeeId(int id, IRepositoryManager repositoryManager)
        {
            if (repositoryManager.Employee.GetById(id).Equals(null))
            {
                throw new EmployeeException("Employe does not exists");
            }
        }
    }
}
