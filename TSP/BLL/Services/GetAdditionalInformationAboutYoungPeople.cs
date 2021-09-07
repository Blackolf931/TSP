using System.Text;

namespace BLL.Services
{
    public class GetAdditionalInformationAboutYoungPeople : IStrategyService
    {
        public bool IsValidStrategy(int age)
        {
            if (age >= 0 && age <= 18)
            {
                return true;
            }
            return false;
        }

        public string SetInformation()
        {
            return new StringBuilder().Append("You are young people").ToString();
        }
    }
}
