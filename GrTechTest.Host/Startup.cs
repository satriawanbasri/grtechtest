using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(GrTechTest.Host.Startup))]
namespace GrTechTest.Host
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}