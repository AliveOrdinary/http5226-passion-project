using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(passion_projectMVP.Startup))]
namespace passion_projectMVP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
