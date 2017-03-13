using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Noleggio.Web.Startup))]
namespace Noleggio.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
