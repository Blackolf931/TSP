using System.Text;

namespace BLL.Services
{
    class GetAdditionalInformationAboutRetirePeople
    {
        public string GetInformation()
        {
            return new StringBuilder().Append("Your are retire").ToString();
        }

        public string ISValidStrategy(int age)
        {
            if (age > 60)
            {
                return GetInformation();
            }
            return new GetAdditionalInformationMiddlePeople().ISValidStrategy(age);
        }
    }
}
