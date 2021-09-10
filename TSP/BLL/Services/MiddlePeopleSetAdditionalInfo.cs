using System.Text;

namespace BLL.Services
{
    public class MiddlePeopleSetAdditionalInfo : IStrategy
    {
        public bool IsValidStrategy(int age)
        {
            if (age > 18 && age < 60)
            {
                return true;
            }
            return false;
        }

        public string SetInformation()
        {
            return new StringBuilder().Append("Your are middle people").ToString();
        }
    }
}
