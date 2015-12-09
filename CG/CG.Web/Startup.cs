using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CG.Web.Startup))]
namespace CG.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
