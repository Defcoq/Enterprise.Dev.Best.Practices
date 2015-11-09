using EA.JP.Ecommerce.Controllers;
using EA.JP.Ecommerce.Infrastructure.Configuration;
using EA.JP.Ecommerce.Infrastructure.Email;
using EA.JP.Ecommerce.Infrastructure.Logging;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EA.JP.Ecommerce.WEB.MVC.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            BootStrapper.ConfigureDependencies();

            Services.AutoMapperBootStrapper.ConfigureAutoMapper();

            ApplicationSettingsFactory.InitializeApplicationSettingsFactory
                                  (ObjectFactory.GetInstance<IApplicationSettings>());

            LoggingFactory.InitializeLogFactory(ObjectFactory.GetInstance<ILogger>());

            EmailServiceFactory.InitializeEmailServiceFactory
                                  (ObjectFactory.GetInstance<IEmailService>());

            ControllerBuilder.Current.SetControllerFactory(new IoCControllerFactory());

            LoggingFactory.GetLogger().Log("Application Started");
        }
    }
}
