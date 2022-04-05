using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAspNetCoreApp
{
    public class RoutingMiddleware
    {
        RequestDelegate next;
        public RoutingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        //http://localhost:8979/index?token=12345 - /index путь запроса
        public async Task InvokeAsync(HttpContext context)
        {
            string path = context.Request.Path.Value.ToLower();
            if (path == "/" || path == "/index")
                await context.Response.WriteAsync("Home Page / /index Message");
            else if (path == "/about")
                await context.Response.WriteAsync("Home Page About Message");
            else
                context.Response.StatusCode = 404;
        }
    }
}
