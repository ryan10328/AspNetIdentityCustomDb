using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AspIdentityCustomDb.Startup))]
namespace AspIdentityCustomDb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
