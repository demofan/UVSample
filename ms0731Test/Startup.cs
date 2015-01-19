using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ms0731Test.Startup))]
namespace ms0731Test
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
