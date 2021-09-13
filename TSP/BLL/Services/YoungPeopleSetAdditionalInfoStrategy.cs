using System.Text;

namespace BLL.Services
{
    public class YoungPeopleSetAdditionalInfo : IStrategy
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
