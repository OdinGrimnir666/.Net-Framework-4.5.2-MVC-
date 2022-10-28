using Autofac;
using Autofac.Integration.Mvc;
using Fram_4._5._2.Controllers;
using Fram_4._5._2.Models;
using Fram_4._5._2.Repository;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataProtection;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Fram_4._5._2.ApplicationSignInManager;

namespace Fram_4._5._2.Utill
{
    public class AutofacConfig
    {

        public static void ConfigureContainer(IAppBuilder app)
        {
            // получаем экземпляр контейнера
            var builder = new ContainerBuilder();

            // регистрируем контроллер в текущей сборке
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // регистрируем споставление типов
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<RegionCentrRepository>().As<IRegionCentrRepository>();


            builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationUserStore>().As<IUserStore<ApplicationUser>>().InstancePerRequest();
            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerRequest();
            builder.Register<IAuthenticationManager>(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();
            builder.Register<IDataProtectionProvider>(c => app.GetDataProtectionProvider()).InstancePerRequest();


            builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerDependency();
            // создаем новый контейнер с теми зависимостями, которые определены выше
            var container = builder.Build();

            // установка сопоставителя зависимостей
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

    }
}