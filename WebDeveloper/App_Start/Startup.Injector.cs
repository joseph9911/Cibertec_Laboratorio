using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using LightInject;

namespace WebDeveloper
{
	public partial class Startup
	{
        public void ConfigInjector()
        {
            var container = new ServiceContainer();
            container.RegisterAssembly(Assembly.GetExecutingAssembly());
            container.RegisterAssembly("WebDeveloper.Model*.dll");
            container.RegisterAssembly("WebDeveloper.Repository*.dll");
            container.RegisterControllers();
            container.EnableMvc();
        }
	}
}