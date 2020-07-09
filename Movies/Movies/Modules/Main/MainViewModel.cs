namespace Movies.Modules.Main
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Input;

    using Movies.Common.Base;
    using Movies.Common.Models;
    using Movies.Common.NavigationService;
    using Movies.Common.Network;
    using Movies.Modules.MovieDetails;

    using Xamarin.Forms;

    public class MainViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;

        private readonly INetworkService _networkService;

        private MovieData _selectedMovie;

        public MainViewModel(INetworkService networkService, INavigationService navigationService)
        {
            this._networkService = networkService;
            this.Items = new ObservableCollection<MovieData>();
            this._navigationService = navigationService;
        }

        public ObservableCollection<MovieData> Items { get; set; }

        public ICommand MovieChangedCommand
        {
            get => new Command(async () => await this.GoToMovieDetails());
        }

        public ICommand PerformSearchCommand
        {
            get => new Command(async () => await this.GetMovieData());
        }

        public string SearchText { get; set; }

        public MovieData SelectedMovie
        {
            get => this._selectedMovie;
            set => this.SetProperty(ref this._selectedMovie, value);
        }

        // still not running correctly after 2:50 #47
        private async Task GetMovieData()
        {
            var result = await this._networkService.GetAsync<ListOfMovies>(ApiConstants.GetApiUri(this.SearchText));
            this.Items = new ObservableCollection<MovieData>(
                result.Search.Select(
                    x => new MovieData(x.Title, x.Poster.Replace("SX300", "SX600"), x.Year, x.ImdbID)));
            this.OnPropertyChanged("Items");
        }

        // this matches the end of #45 and the begining of $46.
        private async Task GoToMovieDetails()
        {
            if (this.SelectedMovie == null) return;

            await this._navigationService.PushAsync<MovieDetailsViewModel>(this.SelectedMovie);
            this.SelectedMovie = null;
        }
    }
}