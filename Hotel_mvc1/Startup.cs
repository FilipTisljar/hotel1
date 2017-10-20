using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hotel_mvc1.Startup))]
namespace Hotel_mvc1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
