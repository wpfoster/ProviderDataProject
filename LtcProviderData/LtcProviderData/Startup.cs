using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LtcProviderData.Startup))]
namespace LtcProviderData
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
