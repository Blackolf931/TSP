﻿using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using TSP.API.Exceptions;

namespace TSP.API.MiddleWare
{
    public class ExceptionMiddleWare
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleWare (RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try 
            {
                await _next.Invoke(context);
            }
            catch(OfficeException ex)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync($"{ex.Message}");
            }
            catch(EmployeeException ex)
            {
                context.Response.StatusCode = StatusCodes.Status409Conflict;
                await context.Response.WriteAsync($"{ex.Message}");
            }
            catch(Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync($"{ex.Message}");
            }
            
        }
    }
}