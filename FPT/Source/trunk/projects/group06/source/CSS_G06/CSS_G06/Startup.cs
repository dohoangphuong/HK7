using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CSS_G06.Startup))]
namespace CSS_G06
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
