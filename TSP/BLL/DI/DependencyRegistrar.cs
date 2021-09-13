using BLL.Services;
using DAl.BusinessLogic;
using DAL.BusinessLogic;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.DI
{
    public static class DependencyRegistrar
    {
        public static void RegistarBuisnessComponents(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IOfficeService, OfficeService>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IOfficeRepository, OfficeRepository>();
            services.AddScoped<IStrategy, RetirePeopleSetadditionalInfoStrategy>();
            services.AddScoped<IStrategy, MiddlePeopleSetAdditionalInfoStrategy>();
            
            services.ConfigureSqlContext(configuration);
        }
        private static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<RepositoryContext>(opts =>
            opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
    }
}
