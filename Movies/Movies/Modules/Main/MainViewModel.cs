namespace Movies.Modules.Main
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Input;

    using Movies.Common.Models;
    using Movies.Common.Network;

    using Xamarin.Forms;

    public class MainViewModel : BindableObject
    {
            private readonly INetworkService _networkService;

            public MainViewModel(INetworkService networkService)
            {
                this._networkService = networkService;
                this.Items = new ObservableCollection<MovieData>();
            }

            public ObservableCollection<MovieData> Items { get; set; }

            public ICommand MovieChangedCommand
            {
                get
                {
                    return new Command(() => { throw new NotImplementedException(); });
                }
            }

            public ICommand PerformSearchCommand
            {
                get => new Command(async () => await this.GetMovieData());
            }

            public string SearchText { get; set; }

            private async Task GetMovieData()
            {
                var result = await this._networkService.GetAsync<ListOfMovies>(ApiConstants.GetApiUri(this.SearchText));
                this.Items.Clear();
                if (result.Search == null || result.Search.Count == 0) return;

                this.Items = new ObservableCollection<MovieData>(
                    result.Search

                        // Eliminate duplicate movies
                        .GroupBy(x => new { x.Title, x.Year }).Select(x => x.First())

                        // Sort by year descending
                        .OrderByDescending(x => x.Year)
                        .Select(x => new MovieData(x.Title, x.Poster.Replace("SX300", "SX600"))));
                this.OnPropertyChanged("Items");
            }
        
    }
}