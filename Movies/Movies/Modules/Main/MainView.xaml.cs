namespace Movies.Modules.Main
{
    using Movies.Common.Network;

    using Xamarin.Forms;

    public partial class MainView : ContentPage
    {
        public MainView()
        {
            this.InitializeComponent();
            this.BindingContext = new MainViewModel(new NetworkService());
        }
    }
}