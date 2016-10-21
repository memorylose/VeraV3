using Autofac;
using Autofac.Integration.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Vera.Business;
using Vera.DataAccess.AdoNet;
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
            builder.RegisterType<UserDal>().As<IUserDataAccess>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            _containerProvider = new ContainerProvider(builder.Build());
        }
    }
}