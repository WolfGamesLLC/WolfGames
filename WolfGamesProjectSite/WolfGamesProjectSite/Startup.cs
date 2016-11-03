using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WolfGamesProjectSite.Startup))]
namespace WolfGamesProjectSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
