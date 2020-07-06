namespace Movies.Modules.MovieDetails
{
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieDetailsView : ContentPage
    {
        public MovieDetailsView(MovieDetailsViewModel viewModel)
        {
            this.InitializeComponent();
            this.BindingContext = viewModel;
        }
    }
}