﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using TestProject8.Exceptions;
using TestProject8.Filters;

namespace TestProject8
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Services.Add(typeof(IExceptionLogger), new GlobalExceptionLogger());
            //config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());

            // RFC 7807 global handler and base URI for exception types


            config.Filters.Add(new NotImplementedExceptionFilter());
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
