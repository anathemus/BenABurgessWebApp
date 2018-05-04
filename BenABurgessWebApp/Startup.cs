using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BenABurgessWebApp.Startup))]
namespace BenABurgessWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
