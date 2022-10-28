using Fram_4._5._2.Utill;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Fram_4._5._2.Startup))]
namespace Fram_4._5._2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
            ConfigureAuth(app);
            AutofacConfig.ConfigureContainer(app);
        }
    }
}
