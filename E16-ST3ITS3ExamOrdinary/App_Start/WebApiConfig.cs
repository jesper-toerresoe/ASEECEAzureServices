using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace E16_ST3ITS3ExamOrdinary
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "LTBGMReport/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
