namespace Movies.Common.NavigationService
{
    using System.Threading.Tasks;

    using Movies.Common.Base;

    public interface INavigationService
    {
        Task PopAsync();

        Task PushAsync<TViewModel>(object parameter = null)
            where TViewModel : BaseViewModel;
    }
}