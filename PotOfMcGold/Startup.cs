using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PotOfMcGold.Startup))]
namespace PotOfMcGold
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
