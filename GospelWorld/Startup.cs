using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GospelWorld.Startup))]
namespace GospelWorld
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
