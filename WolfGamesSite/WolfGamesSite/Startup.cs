using Microsoft.Owin;
using Owin;
using WolfGamesSite.DAL;

[assembly: OwinStartupAttribute(typeof(WolfGamesSite.Startup))]
namespace WolfGamesSite
{
    public partial class Startup
    {
        protected OAuthAppData authorizaation;

        public Startup()
        {
            authorizaation = new OAuthAppData("131000074044017", "7d439d0a74205bc338b6821693959ea9");
        }

        public virtual void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
