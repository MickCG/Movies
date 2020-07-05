namespace Movies
{
    using Xamarin.Forms;

    public class MovieData : BindableObject
    {
        private string _imageSource;

        private string _title;

        public MovieData(string title, string imageUri)
        {
            this._title = title;
            this.Image = imageUri;
        }

        public string Image
        {
            get => this._imageSource;
            set
            {
                this._imageSource = value;
                this.OnPropertyChanged();
            }
        }

        public string Title
        {
            get => this._title;
            set
            {
                this._title = value;
                this.OnPropertyChanged();
            }
        }
    }
}