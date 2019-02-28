using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using XamarinFormsApp.Repository.Definitions;
using XamarinFormsApp.Repository.Implementations;

namespace XamarinFormsApp.Repository
{
    public class AutofacModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SQLiteRepository>().As<ISQLiteRepository>().SingleInstance();
        }
    }
}
