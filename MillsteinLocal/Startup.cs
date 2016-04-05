using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MillsteinLocal.Startup))]
namespace MillsteinLocal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
