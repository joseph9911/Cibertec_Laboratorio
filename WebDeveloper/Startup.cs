using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebDeveloper.Startup))]
namespace WebDeveloper
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
            log4net.Config.XmlConfigurator.Configure();
        }
    }
}
