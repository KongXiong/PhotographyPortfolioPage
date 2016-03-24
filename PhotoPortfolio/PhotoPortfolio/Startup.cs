using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PhotoPortfolio.Startup))]
namespace PhotoPortfolio
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
