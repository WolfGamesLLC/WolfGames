using Microsoft.Owin;
using Owin;
using WolfGamesSite.DAL;

[assembly: OwinStartupAttribute(typeof(WolfGamesSite.Startup))]
namespace WolfGamesSite
{
    public partial class Startup
    {
        protected OAuthAppData authorization;

        public Startup()
        {
            authorization = new OAuthAppData("130984234045601", "91d4430603418cb03bd86065fc4babeb");
        }

        public virtual void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
