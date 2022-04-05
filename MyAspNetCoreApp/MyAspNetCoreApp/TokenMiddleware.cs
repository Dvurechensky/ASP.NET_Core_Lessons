using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAspNetCoreApp
{
    public class TokenMiddleware
    {
        RequestDelegate next;
        string pattern;

        //обязательно для middleware конструктор
        public TokenMiddleware(RequestDelegate next, string pattern)
        {
            this.next = next;
            this.pattern = pattern;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Query["token"];
            if (token != pattern)
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Token is invalid!");
            }
            else
                await next(context); //обращаемся к следующему элементу в конвеере и передаем ему управление обработки запроса
        }
    }

    //Методы расширения для IApplicationBuilder
    public static class TokenExtensions
    {
        public static IApplicationBuilder UseToken(this IApplicationBuilder builder,
            string pattern)
        {
            return builder.UseMiddleware<TokenMiddleware>(pattern);
        }
    }
}
