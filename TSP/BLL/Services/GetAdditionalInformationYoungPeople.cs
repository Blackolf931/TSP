using System.Text;

namespace BLL.Services
{
    public class GetAdditionalInformationYoungPeople
    {
        public string GetInformation()
        {
            return new StringBuilder().Append("You are young people").ToString();
        }

        public string ISValidStrategy(int age)
        {
            if (age > 0 && age <= 18)
            {
               return GetInformation();
            }
            return new StringBuilder().Append("You have incorrect age").ToString();
        }
    }
}
