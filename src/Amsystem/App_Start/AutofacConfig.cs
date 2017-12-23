using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Amsystem.Data.Entities;
using Amsystem.Data.SqlServer.Context;
using Amsystem.Persistense;
using Amsystem.Services;
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
            builder.RegisterType(typeof(AgreementService)).As(typeof(IService<Agreement>)).InstancePerRequest();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            var container = builder.Build();
            return container;
        }
    }
}