namespace Movies.Common.NavigationService
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Autofac;

    using Movies.Common.Base;
    using Movies.Modules.MovieDetails;

    using Xamarin.Forms;

    public class NavigationService : INavigationService
    {
        private readonly IComponentContext _container;

        private readonly Func<INavigation> _navigation;

        private readonly Dictionary<Type, Type> _pageMap = new Dictionary<Type, Type>
                                                               {
                                                                   {
                                                                       typeof(MovieDetailsViewModel),
                                                                       typeof(MovieDetailsView)
                                                                   }
                                                               };

        public NavigationService(Func<INavigation> navigation, IComponentContext container)
        {
            this._navigation = navigation;
            this._container = container;
        }

        public async Task PopAsync()
        {
            await this._navigation().PopAsync();
        }

        public async Task PushAsync<TViewModel>(object parameter = null)
            where TViewModel : BaseViewModel
        {
            var pageType = this._pageMap[typeof(TViewModel)];
            var page = this._container.Resolve(pageType) as Page;
            await this._navigation().PushAsync(page);
            await (page.BindingContext as BaseViewModel).InitializeAsync(parameter);
        }
    }
}