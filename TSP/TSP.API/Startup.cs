using BLL.AutoMapper;
using BLL.DI;
using BLL.Models;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NLog;
using System.IO;
using System.Text.Json.Serialization;
using TSP.API.AutoMapper;
using TSP.API.Filter;
using TSP.API.MiddleWare;
using TSP.API.Validators;
using TSP.API.ViewModels;

namespace TSP.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ApiProfile), typeof(BllProfile));
            services.AddValidatorsFromAssemblyContaining<ValidationFilter>(ServiceLifetime.Transient);
            services.ConfigureLoggerService();
            services.RegistarBuisnessComponents(Configuration);
            services.AddCors();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TSP.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TSP.API v1"));
            }

            app.UseMiddleware<ExceptionMiddleWare>();

            app.UseHttpsRedirection();

            app.UseCors(x => x
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .SetIsOriginAllowed(origin => true)
                       .AllowCredentials());
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

