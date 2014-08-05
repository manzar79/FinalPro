using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MeatMe.Startup))]
namespace MeatMe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
