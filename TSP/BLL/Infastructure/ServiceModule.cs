using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_1.Infastructure
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
