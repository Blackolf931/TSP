using System.Text;

namespace BLL.Services
{
    class GetInformationAboutYoungPeople : IGetAdditionalInformation
    {
        private readonly StringBuilder sb = new();
        public string GetAdditionalInformation()
        {
            return sb.Append("You are young people").ToString();
        }
    }
}
