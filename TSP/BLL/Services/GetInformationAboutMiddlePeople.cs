using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    class GetInformationAboutMiddlePeople : IGetAdditionalInformation
    {
        public string GetAdditionalInformation()
        {
            return new StringBuilder().Append("Your have middle age").ToString();
        }
    }
}
