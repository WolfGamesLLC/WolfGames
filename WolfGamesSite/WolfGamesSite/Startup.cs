using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WolfGamesSite.Startup))]
namespace WolfGamesSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
