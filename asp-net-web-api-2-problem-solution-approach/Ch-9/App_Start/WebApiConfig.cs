﻿using Ch_9.DI;
using DAL;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace Ch_9
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            DependencyResolver.Register<ProductRepository, ProductRepository>();
            DependencyResolver.Register<ProductService, ProductService>();

            //config.DependencyResolver = new TinyIocResolver();

            config
                .Services
                .Replace(typeof(IHttpControllerActivator), new ControllerDependencyInjector());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
