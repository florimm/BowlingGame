using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BowlingGameV2.Startup))]
namespace BowlingGameV2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
