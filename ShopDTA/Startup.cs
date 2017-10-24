using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShopDTA.Startup))]
namespace ShopDTA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
