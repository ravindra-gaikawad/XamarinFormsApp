using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using XamarinFormsApp.Services.Definitions;
using XamarinFormsApp.Services.Implementations;

namespace XamarinFormsApp.Services
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HttpService>().As<IHttpService>().SingleInstance();
            builder.RegisterType<ItemService>().As<IItemService>().SingleInstance();
        }
    }
}
