using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LinkedInMVC.Startup))]
namespace LinkedInMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
