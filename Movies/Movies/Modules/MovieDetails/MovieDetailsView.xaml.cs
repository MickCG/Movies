namespace Movies.Modules.MovieDetails
{
    using System;

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

        async void ImageButton_OnClicked(object sender, EventArgs e)
        {
            await ImageButton.ScaleTo(1.3, 300);
            await ImageButton.ScaleTo(1, 300);
        }
    }
}