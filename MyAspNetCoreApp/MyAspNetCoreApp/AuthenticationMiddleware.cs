using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAspNetCoreApp
{
    public class AuthenticationMiddleware
    {
        RequestDelegate next;
        public AuthenticationMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        //авторизация и идентификация пользователей
        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Query["token"];
            if (string.IsNullOrEmpty(token))
                context.Response.StatusCode = 403;
            else
                await next(context);
        }
    }
}
