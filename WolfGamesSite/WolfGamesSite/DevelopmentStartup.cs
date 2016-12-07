using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute("TestingConfiguration", typeof(WolfGamesSite.DevelopmentStartup))]
namespace WolfGamesSite
{
    public class DevelopmentStartup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            app.Run(context =>
            {
                string t = DateTime.Now.Millisecond.ToString();
                return context.Response.WriteAsync(t + " Development OWIN App");
            });
        }
    }
}
