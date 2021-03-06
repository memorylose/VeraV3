﻿using Autofac;
using Autofac.Integration.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using Vera.Business;
using Vera.DataAccess.Dapper;
using Vera.Interface.BLL;
using Vera.Interface.DAL;

namespace Vera.UI
{
    public class Global : System.Web.HttpApplication, IContainerProviderAccessor
    {
        static IContainerProvider _containerProvider;
        public IContainerProvider ContainerProvider
        {
            get { return _containerProvider; }
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            var builder = new ContainerBuilder();

            //article
            builder.RegisterType<ArticleDal>().As<IArticleDataAccess>();
            builder.RegisterType<ArticleRepository>().As<IArticleRepository>();

            //user
            builder.RegisterType<UserDal>().As<IUserDataAccess>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();

            //dapper
            builder.RegisterType<DapperConnection>().As<IDapperConnection>();

            _containerProvider = new ContainerProvider(builder.Build());

            //add route
            RegisterRoutes(RouteTable.Routes);
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("",
                "home",
                "~/index.aspx");

            routes.MapPageRoute("",
              "add",
              "~/addarticle.aspx");

            routes.MapPageRoute("",
                "home/{pageid}",
                "~/index.aspx");

            routes.MapPageRoute("",
                "home/type/{typeid}",
                "~/index.aspx");

            routes.MapPageRoute("",
             "home/type/{typeid}/{curTypePage}",
             "~/index.aspx");

            routes.MapPageRoute("",
                "article/{id}",
                "~/articles.aspx");

            routes.MapPageRoute("",
                "login",
                "~/Login.aspx");

            routes.MapPageRoute("",
                "register",
                "~/register.aspx");
        }
    }
}