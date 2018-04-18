using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SJTHWeb.Startup))]
namespace SJTHWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
