using EA.WebApi.Common.logging;
using EA.WebApi.Web.Common;
using EA.WebApi.Web.Common.ErrorHandling;
using EA.WebApi.Web.Common.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Routing;
using System.Web.Http.Tracing;

namespace EA.WebApi.Web.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            var constraintsResolver = new DefaultInlineConstraintResolver();
            constraintsResolver.ConstraintMap.Add("apiVersionConstraint", typeof(ApiVersionConstraint));
            config.MapHttpAttributeRoutes(constraintsResolver);
            config.Services.Replace(typeof(IHttpControllerSelector),new NamespaceHttpControllerSelector(config));

            //config.EnableSystemDiagnosticsTracing();
            config.Services.Replace(typeof(ITraceWriter),new SimpleTraceWriter(WebContainerManager.Get<ILogManager>()));
            config.Services.Add(typeof(IExceptionLogger),new SimpleExceptionLogger(WebContainerManager.Get<ILogManager>()));
            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());





            // Web API routes
            //config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
        }
    }
}
