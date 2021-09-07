using System.Text;

namespace BLL.Services
{
    class GetAdditionalInformationAboutRetirePeople : IStrategyService
    {
        public string SetInformation()
        {
            return new StringBuilder().Append("Your are retire").ToString();
        }

        bool IStrategyService.IsValidStrategy(int age)
        {
            if (age > 60)
            {
                return true;
            }
            return false;
        }
    }
}
