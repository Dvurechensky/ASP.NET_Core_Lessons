using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAspNetCoreApp
{
    public class ErrorHandlingMiddleware
    {
        RequestDelegate next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await next(context);
            if (context.Response.StatusCode == 403)
                await context.Response.WriteAsync("Access Denied");
            if (context.Response.StatusCode == 404)
                await context.Response.WriteAsync("Not Found");
        }
    }
}
