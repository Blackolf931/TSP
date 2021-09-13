using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class YoungPeopleSetAdditionalInfoStrategy : IStrategy
    {
        public bool IsValidStrategy(int age)
        {
            if (age > 0 && age <= 18)
            {
                return true;
            }
            return false;
        }

        public string SetInformation()
        {
            return new StringBuilder().Append("Your are young people").ToString();
        }
    }
}
