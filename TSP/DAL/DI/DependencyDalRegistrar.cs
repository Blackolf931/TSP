using DAl.EF;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.DI
{
    public static class DependencyDalRegistrar
    {
        public static void RegistarDalComponents(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IOfficeRepository, OfficeRepository>(); ;
            services.ConfigureSqlContext(configuration);
        }
        private static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<RepositoryContext>(opts =>
            opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));

    }
}
