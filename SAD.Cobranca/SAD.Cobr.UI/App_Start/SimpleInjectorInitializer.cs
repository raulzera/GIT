using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using SAD.Cobr.UI.App_Start;
using SAD.Cobr.UI.App_Start.CC.SAD.Dashboard.UI.Site;
using SAD.Cobr.UI.Models;
using SAD.Cobranca.Infra.CrossCutting.IoC;
using SimpleInjector;
using SimpleInjector.Advanced;
using SimpleInjector.Integration.Web;
using Container = SimpleInjector.Container;

[assembly: PostApplicationStartMethod(typeof(SimpleInjectorInitializer), "Initialize")]
namespace SAD.Cobr.UI.App_Start
{
   public static class SimpleInjectorInitializer
        {
            public static void Initialize()
            {
                var container = new Container();
                container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

                InitializeContainer(container);

                container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
                container.Verify();

                DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            }

            private static void InitializeContainer(Container container)
            {
                BootStrapperApplication.RegisterServices(container);
                BootStrapperDomain.RegisterServices(container);
                BootStrapperInfra.RegisterServices(container);

                container.Register<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(new ApplicationDbContext()), Lifestyle.Scoped);
                container.Register<IRoleStore<IdentityRole, string>>(() => new RoleStore<IdentityRole>(), Lifestyle.Scoped);
                container.Register<IAuthenticationManager>(() => AdvancedExtensions.IsVerifying(container)
                    ? new OwinContext(new Dictionary<string, object>()).Authentication
                    : HttpContext.Current.GetOwinContext().Authentication, Lifestyle.Scoped);

                container.Register<ApplicationUserManager>(Lifestyle.Scoped);
                container.Register<ApplicationSignInManager>(Lifestyle.Scoped);
            }
        }
    }