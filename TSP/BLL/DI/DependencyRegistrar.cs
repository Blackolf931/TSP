using BLL.Services;
using DAL.DI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.DI
{
    public static class DependencyRegistrar
    {
        public static void RegistarBuisnessComponents(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IStrategy, RetirePeopleSetadditionalInfoStrategy>();
            services.AddScoped<IStrategy, MiddlePeopleSetAdditionalInfoStrategy>();
            services.AddScoped<IStrategy, YoungPeopleSetAdditionalInfoStrategy>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IOfficeService, OfficeService>();
            DependencyDalRegistrar.RegistarDalComponents(services, configuration);
        }
    }
}