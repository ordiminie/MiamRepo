using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Miam.Startup))]
namespace Miam
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
