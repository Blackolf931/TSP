using System.Text;

namespace BLL.Services
{
    public class RetirePeopleSetadditionalInfoStrategy : IStrategy
    {
        public string SetInformation()
        {
            return new StringBuilder().Append("Your are retire").ToString();
        }
        public bool IsValidStrategy(int age)
        {
            if (age > 60)
            {
                return true;
            }
            return false;
        }
    }
}
