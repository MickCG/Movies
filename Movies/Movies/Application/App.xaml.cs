﻿namespace Movies.Application
{
    using System;
    using System.Reflection;

    using Autofac;

    using Movies.Common.NavigationService;
    using Movies.Modules.Main;

    using Xamarin.Forms;

    public partial class App : Application
    {
        public App()
        {
            this.InitializeComponent();

            // class used for registration
            var builder = new ContainerBuilder();

            // scan and register all classes in the assembly
            var dataAccess = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(dataAccess).AsImplementedInterfaces().AsSelf();

            // register navigation service
            NavigationPage navigationPage = null;
            Func<INavigation> navigationFunc = () => { return navigationPage.Navigation; };
            builder.RegisterType<NavigationService>().As<INavigationService>()
                .WithParameter("navigation", navigationFunc);

            // get container
            var container = builder.Build();

            // set first page
            navigationPage = new NavigationPage(container.Resolve<MainView>());
            this.MainPage = navigationPage;
        }

        protected override void OnResume()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnStart()
        {
        }
    }
}