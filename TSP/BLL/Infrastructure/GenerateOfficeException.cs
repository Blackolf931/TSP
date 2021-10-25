using BLL.Models;
using System.Text.RegularExpressions;

namespace BLL.Infrastructure
{
    public class GenerateOfficeException
    {
        public GenerateOfficeException(Office? officeDto)
        {
            if (officeDto is null) return;
            CheckData(officeDto.Id);
            CheckData(officeDto.Name);
            CheckData(officeDto.Country);
        }

        private static void CheckData(int id)
        {
            if (id <= 0)
                throw new OfficeException("Id cannot be less or equals zero");
        }

        private static void CheckData(string? str)
        {
            if (string.IsNullOrWhiteSpace(str))
                throw new OfficeException("String cannot be less or equals null");

            Regex r = new(@"[\d!#h]");
            if (r.IsMatch(str))
            {
                throw new OfficeException("String have wrong symbols");
            }
        }
    }
}