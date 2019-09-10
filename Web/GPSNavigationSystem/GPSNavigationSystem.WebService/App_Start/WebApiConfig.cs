using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace GPSNavigationSystem.WebService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "ApiWithActionForHouse",
                routeTemplate: "api/{controller}/{action}/{id}/{id2}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Web API routes
            //config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "ApiWithAction",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );



    //        config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling =
    //Newtonsoft.Json.PreserveReferencesHandling.All;
        }
    }
}
