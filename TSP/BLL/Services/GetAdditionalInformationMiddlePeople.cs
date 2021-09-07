using System.Text;

namespace BLL.Services
{
    public class GetAdditionalInformationMiddlePeople
    {
        public string GetInformation()
        {
            return new StringBuilder().Append("Your are middle people").ToString();
        }

        public string ISValidStrategy(int age)
        {
            if (age > 18 && age < 60)
            {
                return GetInformation();
            }
            return new GetAdditionalInformationYoungPeople().ISValidStrategy(age); 
        }
    }
}
