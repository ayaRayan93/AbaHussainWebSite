using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AbaHussainWebSite.Startup))]
namespace AbaHussainWebSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
