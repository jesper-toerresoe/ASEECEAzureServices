using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace F16_ST3P3Opgave
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
                routeTemplate: "st3p3eventservice/{controller}/{id}",
                //routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            /*
           * http://www.asp.net/web-api/overview/formats-and-model-binding/json-and-xml-serialization
           */
            config.Formatters.XmlFormatter.UseXmlSerializer = true;
        }
    }
}
