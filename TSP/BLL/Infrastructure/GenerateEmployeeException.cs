using BLL.Models;
using System.Text.RegularExpressions;

namespace BLL.Infrastructure
{
    public class GenerateEmployeeException
    {
        public GenerateEmployeeException(Employee? dto)
        {
            if (dto is null) return;
            CheckData(dto.Id);
            CheckData(dto.Name);
            CheckData(dto.Patronymic);
            CheckData(dto.Age);
            CheckData(dto.Position);
        }

        private static void CheckData(int id)
        {
            if (id <= 0)
                throw new EmployeeException("Id cannot be less or equals zero");
        }

        private static void CheckData(string? str)
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