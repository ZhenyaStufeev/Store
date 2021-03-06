﻿using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Store.BLL.Services;
using Microsoft.AspNet.Identity;
using Store.BLL.Interfaces;
using System.Web.Http;

[assembly: OwinStartup(typeof(Store.App_Start.Startup))]

namespace Store.App_Start
{
    public class Startup
    {
        IServiceCreator serviceCreator = new ServiceCreator();
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<IUserService>(CreateUserService);
            app.CreatePerOwinContext<IStoreService>(CreateStoreService);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }

        private IUserService CreateUserService()
        {
            return serviceCreator.CreateUserService("entityFramework");
        }

        private IStoreService CreateStoreService()
        {
            return serviceCreator.CreateStoreService("entityFramework");
        }


    }
}