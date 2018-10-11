using Microsoft.Owin;
using Owin;
using SAD.Cobranca.UI;

[assembly: OwinStartup(typeof(Startup))]
namespace SAD.Cobranca.UI

{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}