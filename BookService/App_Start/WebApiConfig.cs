using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BookService
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
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            /*
             * http://www.asp.net/web-api/overview/formats-and-model-binding/json-and-xml-serialization
             */
            config.Formatters.XmlFormatter.UseXmlSerializer = true;
            //jrt 20160808 Change server to use MS XmlSerializatior instead of DataContractSerializer in XML responses
           
            //config.Formatters.JsonFormatter.UseDataContractJsonSerializer = true;
            //jrt 20160818 Change server to use MS XmlSerialization instead of DataContractSerializer in XML responses

            //config.Formatters.JsonFormatter.
            //config.Formatters.XmlFormatter.

        }
    }
}
