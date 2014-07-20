using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MTN_Software_MVC.Startup))]
namespace MTN_Software_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
