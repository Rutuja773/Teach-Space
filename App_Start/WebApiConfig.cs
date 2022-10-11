﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
//using System.Web.Cors;

namespace Teach_Space
{
    public static class WebApiConfig
    {

        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();


            config.Routes.MapHttpRoute("DefaultApiWithAction", "Api/{controller}/{action}");

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");
            //config.EnableCors(cors);

        }
    }
}
