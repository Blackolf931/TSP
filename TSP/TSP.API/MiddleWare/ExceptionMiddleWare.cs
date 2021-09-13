using BLL.Infastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace TSP.API.MiddleWare
{
    public class ExceptionMiddleWare
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleWare (RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context, ILogger<ExceptionMiddleWare> logger)
        {
            try 
            {
                await _next.Invoke(context);
            }
            catch(OfficeException ex)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync($"{ex.Message}");
                logger.LogError(ex.Message);
            }
            catch(EmployeeException ex)
            {
                context.Response.StatusCode = StatusCodes.Status409Conflict;
                await context.Response.WriteAsync($"{ex.Message}");
                logger.LogError(ex.Message);
            }
            catch(Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync($"{ex.Message}");
                logger.LogError(ex.Message);
            }
        }
    }
}
