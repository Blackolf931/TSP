using BLL.Services;
using DAl.EF;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.DI
{
    public static class DependencyRegistrar
    {
        public static void RegistarBuisnessComponents(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IOfficeService, OfficeService>();
            services.AddScoped<IStrategy, RetirePeopleSetadditionalInfoStrategy>();
            services.AddScoped<IStrategy, MiddlePeopleSetAdditionalInfoStrategy>();
            services.AddScoped<IStrategy, YoungPeopleSetAdditionalInfoStrategy>();
            services.ConfigureSqlContext(configuration);
        }
        private static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<RepositoryContext>(opts =>
            opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
    }
}
