using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppMVC5.Startup))]
namespace WebAppMVC5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
