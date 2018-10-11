using SAD.Cobranca.Domain.Identity.Interfaces;
using SAD.Cobranca.Domain.Identity.UsuarioClaim.Interfaces;
using SAD.Cobranca.Infra.Data.IoC.Context;
using SAD.Cobranca.Infra.Data.IoC.Identity.Repository;
using SAD.Cobranca.Infra.Data.IoC.UnitOfWork;
using SimpleInjector;


namespace SAD.Cobranca.Infra.CrossCutting.IoC
{
    public class BootStrapperInfra
    {
        public static void RegisterServices(Container container)
        {
            container.Register<IClaimsRepository, ClaimsRepository>(Lifestyle.Scoped);
            container.Register<IUsuarioClaimsRepository, UsuarioClaimsRepository>(Lifestyle.Scoped);

            container.Register<ApplicationDbContext>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
        }
    }
}