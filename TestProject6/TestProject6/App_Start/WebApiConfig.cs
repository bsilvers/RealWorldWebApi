using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TestProject6.AuthFilters;
using TestProject6.Handlers;

namespace TestProject6
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            config.SuppressHostPrincipal();
            config.MessageHandlers.Add(new ForwardedHeadersHandler());
            config.Filters.Add(new BasicAuthFilterAttribute());
            config.Filters.Add(new JwtAuthenticationFilterAttribute());
            config.Filters.Add(new RequireHttpsAttribute());
            config.Filters.Add(new RequireClaimAttribute());

            config.Filters.Add(new AuthorizeAttribute()); // makes every method to have authorize

            
            // Web API routes
            config.MapHttpAttributeRoutes();
            
            
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
        }
    }
}
