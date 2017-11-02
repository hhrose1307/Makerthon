using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TravelWeb.Startup))]
namespace TravelWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
