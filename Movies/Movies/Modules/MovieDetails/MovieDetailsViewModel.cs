namespace Movies.Modules.MovieDetails
{
    using System.Threading.Tasks;
    using System.Windows.Input;

    using Movies.Common.Base;
    using Movies.Common.Models;
    using Movies.Common.NavigationService;
    using Movies.Common.Network;

    using Xamarin.Forms;

    public class MovieDetailsViewModel : BaseViewModel
    {
        private bool _isFavorite;

        private MovieData _movieData;

        // Last addition at end of #47
        private FullMovieInformation _movieInformation;

        private readonly INavigationService _navigationService;

        private readonly INetworkService _networkService;

        public MovieDetailsViewModel(INavigationService navigationService, INetworkService networkService)
        {
            this._navigationService = navigationService;
            this._networkService = networkService;
        }

        public ICommand FavoriteCommand => new Command(async () => await this.SetMovieFavorite());

        public ICommand GoBackCommand
        {
            get => new Command(async () => await this.GoBack());
        }

        public bool IsFavorite
        {
            get => this._isFavorite;
            set => this.SetProperty(ref this._isFavorite, value);
        }

        public MovieData MovieData
        {
            get => this._movieData;
            set => this.SetProperty(ref this._movieData, value);
        }

        public FullMovieInformation MovieInformation
        {
            get => this._movieInformation;
            set => this.SetProperty(ref this._movieInformation, value);
        }

        public override async Task InitializeAsync(object parameter)
        {
            this.MovieData = (MovieData)parameter;
            this.MovieInformation =
                await this._networkService.GetAsync<FullMovieInformation>(
                    ApiConstants.GetMovieById(this.MovieData.IMdbID));
        }

        private async Task GoBack()
        {
            await this._navigationService.PopAsync();
        }

        private async Task SetMovieFavorite()
        {
            this.IsFavorite = !this.IsFavorite;
        }
    }
}