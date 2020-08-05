using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PreUni.OnlineTest.Web.MVC.Startup))]
namespace PreUni.OnlineTest.Web.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
