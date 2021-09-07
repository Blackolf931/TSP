using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    class StrategyService : IStrategyService
    {
        public string ISValidStrategy(int age)
        {
            return new GetAdditionalInformationAboutRetirePeople().ISValidStrategy(age);
        }
    }
}
