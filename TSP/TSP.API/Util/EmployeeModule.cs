using BLL.Interface;
using BLL.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TSP.API.Util
{
    public class EmployeeModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IEmployeeService>().To<EmployeeService>();
        }
    }
}
