using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TSP.API.Exceptions
{
    public class GenerateOfficeException
    {
        public GenerateOfficeException()
        {
        }

        public void CheckData(int id)
        {
            if (id <= 0)
                throw new OfficeException("Id cannot be less or equals zero");
        }
        public void CheckData(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                throw new OfficeException("String cannot be less or equals null");

            Regex r = new(@"[\d!#h]");
            if (r.IsMatch(str))
            {
                throw new OfficeException("String have wrong symbols");
            }
        }
        public void CheckOfficeId(int id, IRepositoryManager repositoryManager)
        {
            if (repositoryManager.Office.GetById(id) is null)
            {
                throw new OfficeException("Office does not exist");
            }
        }
    }
}
