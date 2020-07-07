namespace Movies.Modules.MovieDetails
{
    using System.Threading.Tasks;

    using Movies.Common.Base;
    using Movies.Common.Models;
    using Movies.Common.NavigationService;
    using Movies.Common.Network;

    public class MovieDetailsViewModel : BaseViewModel
    {
        private INetworkService _networkService;
        private INavigationService _navigationService;

        private MovieData _movieData;

        public MovieDetailsViewModel(INavigationService navigationService, INetworkService networkService)
        {
            this._navigationService = navigationService;
            this._networkService = networkService;
        }

        public MovieData MovieData
        {
            get => this._movieData;
            set => this.SetProperty(ref this._movieData, value);
        }

        private FullMovieInformation _movieInformation;

        public FullMovieInformation MovieInformation
        {
            get => this._movieInformation;
            set => SetProperty(ref this._movieInformation, value);
        }

        public override async Task InitializeAsync(object parameter)
        {
            this.MovieData = (MovieData)parameter;
            MovieInformation = await _networkService.GetAsync<FullMovieInformation>(ApiConstants.GetMovieById(MovieData.IMdbID));

        }
    }
}