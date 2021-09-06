using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    class GetInformationAboutRetirePeople : IGetAdditionalInformation
    {
        public string GetAdditionalInformation()
        {
            return new StringBuilder().Append("Your are retire").ToString();
        }
    }
}
