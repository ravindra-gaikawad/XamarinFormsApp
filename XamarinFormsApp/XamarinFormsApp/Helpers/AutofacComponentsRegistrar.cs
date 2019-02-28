using Autofac;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace XamarinFormsApp.Helpers
{
    public sealed class AutofacComponentsRegistrar
    {
        public static void RegisterAssemblyModules(ContainerBuilder builder)
        {
            builder.RegisterAssemblyModules(typeof(XamarinFormsApp.Repository.AutofacModule).Assembly);
            builder.RegisterAssemblyModules(typeof(XamarinFormsApp.Services.AutofacModule).Assembly);
            builder.RegisterAssemblyModules(typeof(XamarinFormsApp.Utilities.AutofacModule).Assembly);
            builder.RegisterAssemblyModules(typeof(XamarinFormsApp.AutofacModule).Assembly);
        }
    }
}
