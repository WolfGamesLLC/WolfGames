using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using WolfGamesSite.DAL;

[assembly: OwinStartupAttribute("TestingConfiguration", typeof(WolfGamesSite.DevelopmentStartup))]
namespace WolfGamesSite
{
    public class DevelopmentStartup : Startup
    {
        public DevelopmentStartup()
        {
            authorization = new OAuthAppData("131000074044017", "7d439d0a74205bc338b6821693959ea9");
        }
    }
}
