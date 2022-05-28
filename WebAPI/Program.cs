using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DepencdencyResolvers.Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureContainer<ContainerBuilder>(builder=> {
                builder.RegisterModule(new AutofacBusinessModule());
            })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        //Eger autofav vazgecersek degiþtirecegimiz yerler  .UseServiceProviderFactory(new AutofacServiceProviderFactory()) new AutofacServiceProviderFactory sadece bunu degiþtirecegiz
        // builder.RegisterModule(new AutofacBusinessModule()); bide business katmanýndaki sýnof ismi degiþecek AutofacBusinessModule
        //baþka degiþtirecegimiz yerler yoktur sadece iki sýnýf degiþecek.
    }
}
