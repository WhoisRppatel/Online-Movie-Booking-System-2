using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShowTime.Startup))]
namespace ShowTime
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
