using SAD.Cobranca.Application.Identity.Claims.Interfaces;
using SAD.Cobranca.Application.Identity.Claims.Services;
using SAD.Cobranca.Application.Identity.UsuarioClaims.Interfaces;
using SAD.Cobranca.Application.Identity.UsuarioClaims.Services;
using SimpleInjector;

namespace SAD.Cobranca.Infra.CrossCutting.IoC
{
    public class BootStrapperApplication
    {
        public static void RegisterServices(Container container)
        {
            container.Register<IUsuarioClaimsAppService, UsuarioClaimsAppService>(Lifestyle.Scoped);
            container.Register<IClaimsAppService, ClaimsAppService>(Lifestyle.Scoped);
        }
    }
}
