using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SAD.Cobr.UI.Startup))]
namespace SAD.Cobr.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
