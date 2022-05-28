using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Entities.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstrsct;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DepencdencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        // services.AddSingleton<IProductService,ProductManager>();
        //  services.AddSingleton<IProductDal, EfProductDal>(); 
        //Autofac ve onun sınıfı olan Module sayesinde yukarıdaki işlemleri
        //burada yapmaamızı saglıyor ve verimliligi artmış oluyor.
        //yukarıdaki kodlar WeabAPI startup yer alaln kodlardır.
        protected override void Load(ContainerBuilder builder)
        {
            // services.AddSingleton<IProductService,ProductManager>();
            //aşagıdaki kod yukarıdaki startupdaki işleme karşılık veriyor.
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();

            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
