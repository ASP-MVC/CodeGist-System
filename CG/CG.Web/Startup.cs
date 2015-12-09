using CG.Web;

using Microsoft.Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace CG.Web
{
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}