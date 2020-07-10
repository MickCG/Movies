namespace Movies.Application
{
    using System;
    using System.Reflection;

    using Autofac;

    using Movies.Common.Database;
    using Movies.Common.Models;
    using Movies.Common.NavigationService;
    using Movies.Modules.Main;
    using Plugin.SharedTransitions;
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
            builder.RegisterType<Repository<FullMovieInformation>>().As<IRepository<FullMovieInformation>>();

            // register navigation service
            SharedTransitionNavigationPage navigationPage = null;
            Func<INavigation> navigationFunc = () => { return navigationPage.Navigation; };
            builder.RegisterType<NavigationService>().As<INavigationService>()
                .WithParameter("navigation", navigationFunc);

            // get container
            var container = builder.Build();

            // set first page
            navigationPage = new SharedTransitionNavigationPage(container.Resolve<MainView>());
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