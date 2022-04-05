using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MyAspNetCoreApp
{
    /// <summary>
    /// Для создания и инициализации хоста
    /// И для логики обработки запросов
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            //0 - лучше внести в отдельные файлы логику обработки запросов
            //using (var host = WebHost.Start("http://localhost:8080", 
            //       context => context.Response.WriteAsync("Hello WebHost!")))
            //{
            //    Console.WriteLine("Application has been started!");
            //    host.WaitForShutdown();//блокирует вызывающий поток пока не нажали Ctr+C
            //}
            //1
            CreateWebHostBuilder(args).Build().Run();
            //2
            //var host = new WebHostBuilder()
            //    .UseKestrel()//передает в приложение запросы
            //    .UseContentRoot(Directory.GetCurrentDirectory())
            //    .UseIISIntegration()//proxy server 
            //    .UseStartup<Startup>()
            //    .Build();
            //host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
                //.UseWebRoot("static");
    }
}
