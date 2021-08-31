using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace TSP.API.MiddleWare
{
    public class TokenMiddleware
    {
        private readonly RequestDelegate _next;
        readonly string pattern;
        public TokenMiddleware(RequestDelegate next, string pattern)
        {
            _next = next;
            this.pattern = pattern;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Query["token"];
            if (token != pattern)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Token is invalid");
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
