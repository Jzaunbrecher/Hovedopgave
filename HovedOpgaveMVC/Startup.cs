using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HovedOpgaveMVC.Startup))]
namespace HovedOpgaveMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
