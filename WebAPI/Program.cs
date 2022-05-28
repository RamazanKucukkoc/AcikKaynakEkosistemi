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
        //Eger autofav vazgecersek degi�tirecegimiz yerler  .UseServiceProviderFactory(new AutofacServiceProviderFactory()) new AutofacServiceProviderFactory sadece bunu degi�tirecegiz
        // builder.RegisterModule(new AutofacBusinessModule()); bide business katman�ndaki s�nof ismi degi�ecek AutofacBusinessModule
        //ba�ka degi�tirecegimiz yerler yoktur sadece iki s�n�f degi�ecek.
    }
}
