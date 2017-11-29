using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Amsystem.Data.SqlServer.Context;
using Amsystem.Persistense;
using Autofac;
using Autofac.Integration.Mvc;

namespace Amsystem
{
    public class AutofacConfig
    {
        public static IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType(typeof(AmsystemDbContext)).InstancePerRequest();
            builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork)).InstancePerRequest();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            var container = builder.Build();
            return container;
        }
    }
}