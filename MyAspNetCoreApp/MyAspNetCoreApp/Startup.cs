using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MyAspNetCoreApp.services;

namespace MyAspNetCoreApp
{
    public class Startup
    {
        string name;
        public Startup()
        {
            name = "Tom";
        }

        //Управление жизненным циклом зависимостей
        //Transient - при каждом получении объекта сервиса будет создаваться
        //отдельный экземпляр этого сервиса

        //Scoped - один экземпляр сервиса на весь запрос

        //Singleton - один экземпляр сервиса на весь период жизни приложения

        //DEPENDENCY INJECTION
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddTransient<IMessageSender, EmailMessageSender>();
            services.AddTransient<MessageService>();
            services.AddTransient<TimeService>();
            services.AddScoped<ICounter, RandomCounter>();
            services.AddScoped<CounterService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // public delegate Task RequestDelegate(HttpContext context)
        // Middleware
        // определяется один раз
        public void Configure(IApplicationBuilder app, IMessageSender msg, TimeService time)
        {
            //int x = 5;
            //int y = 2;
            //int z = 0;
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //Компоненты для обработки запрос
            //DefaultFilesOptions opt = new DefaultFilesOptions();
            //opt.DefaultFileNames.Clear();
            //opt.DefaultFileNames.Add("hello.html");

            //app.UseDefaultFiles(opt); //Для добавления файлов по умолчанию index.html default.html
            //app.UseStaticFiles(); //Для работы со статическими файлами
            //Для встраивания своих компонентов Middleware в конвеер мы можем использовать 
            //app.Use(async (context, next) =>
            //{
            //    z = x * y;
            //    //await context.Response.WriteAsync("Use Method");
            //    await next();
            //    z = z * 5;
            //    await context.Response.WriteAsync($"z = {z}");
            //});
            //Map - для сопосталения пути запроса с определенным делегатом
            //который обработает запрос по этому пути
            //app.Map("/home", home =>
            //{
            //    home.Map("/jobs", (appBuilder) => //home/jobs
            //    {
            //        appBuilder.Run(async (context) =>
            //                        await context.Response.WriteAsync($"<h2>JOB</h2>"));
            //    });
            //    home.Map("/resume", (appBuilder) =>//home/jobs
            //    {
            //        appBuilder.Run(async (context) =>
            //                        await context.Response.WriteAsync($"<h2>Resume</h2>"));
            //    });
            //});
            //app.Map("/index", (appBuilder) =>
            //{
            //    appBuilder.Run(async (context) =>
            //                    await context.Response.WriteAsync($"<h2>Home Page</h2>"));
            //});
            //app.Map("/about", About);
            //app.MapWhen();
            //app.UseWhen();
            //app.Run();
            //app.UseMiddleware();

            //app.UseMiddleware<TokenMiddleware>();

            //app.UseMiddleware<ErrorHandlingMiddleware>();
            //app.UseMiddleware<AuthenticationMiddleware>();
            //app.UseToken("5555");
            //app.UseMiddleware<RoutingMiddleware>();

            //app.Run(async (context) =>
            //{
            //    MessageService senderMsg = context.RequestServices.GetService<MessageService>(); //null - если сервис не добавлен
            //    MessageService senderMsg1 = context.RequestServices.GetRequiredService<MessageService>(); //exception - если сервис не добавлен
            //    //z = z * 2;
            //    //await context.Response.WriteAsync($" z={z}");
            //    //await Handle(context, z); //только один обрабатывается после метода Run ничего не обрабатывается
            //    //await Task.FromResult(0); //возвращает управление в Use 
            //    //await context.Response.WriteAsync($"<h2>NOT FOUND</h2>");
            //    await context.Response.WriteAsync(msg.Send() + "  " + time.GetTime() + "  " + senderMsg?.SendMessage());
            //});

            //app.UseMiddleware<MessageMiddleware>();

            app.UseMiddleware<CounterMiddleware>();
        }

        private void About(IApplicationBuilder app)
        {
            app.Run(async (context) =>
                                           await context.Response.WriteAsync($"<h2>About</h2>"));
        }

        private async Task Handle(HttpContext context, int _z)
        {
            string host = context.Request.Host.Value;
            string path = context.Request.Path;
            string query = context.Request.QueryString.Value;
            context.Response.ContentType = "text/html;charset=UTF-8";
            await context.Response.WriteAsync(//$"Hello {name} x = {x} "
                $"<h1>z: {_z} </h1>" +
                $"<h1>Хост: {host} </h1>" +
                $"<h1>Путь запроса: {path} </h1>" +
                $"<h1>Параметры строки запроса: {query} </h1>");
        }
    }
}
