using Microsoft.AspNetCore.Http;
using MyAspNetCoreApp.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAspNetCoreApp
{
    public class CounterMiddleware
    {
        int i = 0;

        public CounterMiddleware(RequestDelegate next)
        {

        }

        public async Task InvokeAsync(HttpContext context, ICounter counter,
            CounterService counterService)
        {
            i++;

            await context.Response.WriteAsync($"Request: {i} ICounter: {counter.Value}" +
                $"CounterService: {counterService.Counter.Value}");
        }
    }
}
