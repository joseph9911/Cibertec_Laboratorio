using LightInject;
using System.Reflection;

namespace WebDeveloper
{
    public partial class Startup
    {
        public void ConfigInjector()
        {
            var container = new ServiceContainer();
            container.RegisterAssembly(Assembly.GetExecutingAssembly());
            container.RegisterAssembly("WebDeveloper.Repository*.dll");
            container.RegisterAssembly("WebDeveloper.Model*.dll");
            container.RegisterControllers();            
            container.EnableMvc();            
        }
    }
}