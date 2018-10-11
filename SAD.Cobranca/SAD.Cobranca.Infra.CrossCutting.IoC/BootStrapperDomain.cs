using SAD.Cobranca.Domain.Identity;
using SAD.Cobranca.Domain.Identity.Interfaces;
using SAD.Cobranca.Domain.Identity.UsuarioClaim.Interfaces;
using SAD.Cobranca.Domain.Identity.UsuarioClaim.Services;
using SimpleInjector;

namespace SAD.Cobranca.Infra.CrossCutting.IoC
{
    public class BootStrapperDomain
    {
        public static void RegisterServices(Container container)
        {
            container.Register<IClaimsService, ClaimsService>(Lifestyle.Scoped);
            container.Register<IUsuarioClaimsService, UsuarioClaimService>(Lifestyle.Scoped);
        }
    }
}
