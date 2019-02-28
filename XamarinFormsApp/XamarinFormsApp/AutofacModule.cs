using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using XamarinFormsApp.ViewModels;
using XamarinFormsApp.Views;

namespace XamarinFormsApp
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MainPage>().SingleInstance();

            builder.RegisterType<ItemsPage>().InstancePerDependency();
            builder.RegisterType<AboutPage>().InstancePerDependency();

            builder.RegisterType<ItemsViewModel>().InstancePerDependency();
        }
    }
}
