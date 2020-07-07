namespace Movies.Modules.Main
{
    using Xamarin.Forms;

    public partial class MainView : ContentPage
    {
        public MainView(MainViewModel viewModel)
        {
            this.InitializeComponent();
            this.BindingContext = viewModel;
        }
    }
}