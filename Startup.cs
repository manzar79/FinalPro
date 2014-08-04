using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FinalPro.Startup))]
namespace FinalPro
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
