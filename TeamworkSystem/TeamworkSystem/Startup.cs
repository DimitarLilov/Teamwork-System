using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TeamworkSystem.Startup))]
namespace TeamworkSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
