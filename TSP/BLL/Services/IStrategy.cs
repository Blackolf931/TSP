namespace BLL.Services
{
    public interface IStrategy
    {
        string SetInformation();
        bool IsValidStrategy(int age);
    }
}