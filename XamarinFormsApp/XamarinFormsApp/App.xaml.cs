using Autofac;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsApp.Helpers;
using XamarinFormsApp.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XamarinFormsApp
{
    public partial class App : Application
    {
        // IContainer and ContainerBuilder are provided by Autofac
        public static IContainer Container { get; set; }

        public App()
        {
            InitializeComponent();

            var builder = new ContainerBuilder();
            AutofacComponentsRegistrar.RegisterAssemblyModules(builder);
            Container = builder.Build();

            MainPage = App.Container.Resolve<MainPage>();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
