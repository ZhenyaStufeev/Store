﻿using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Store.BLL.Services;
using Microsoft.AspNet.Identity;
using Store.BLL.Interfaces;

[assembly: OwinStartup(typeof(Store.App_Start.Startup))]

namespace Store.App_Start
{
    public class Startup
    {
        IServiceCreator serviceCreator = new ServiceCreator();
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<IUserService>(CreateUserService);
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



    }
}