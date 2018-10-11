using System.Reflection;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SAD.Cobranca.Infra.CrossCutting.IoC;
using SAD.Cobranca.UI;
using SAD.Cobranca.UI.Models;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using WebActivatorEx;
using Container = SimpleInjector.Container;

[assembly: PostApplicationStartMethod(typeof(SimpleInjectorInitializer), "Initialize")]
namespace SAD.Cobranca.UI
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

            container.Register<IUserStore<ApplicationUser>>();
        }
    }
}