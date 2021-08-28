
namespace BLL.Infastructure
{
    public class ServiceModule
    {
        private readonly string connectionString;
        public ServiceModule(string connection)
        {
            connectionString = connection;
        }
    }
}
