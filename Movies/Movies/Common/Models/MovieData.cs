namespace Movies.Common.Models
{
    using Xamarin.Forms;

    public class MovieData : BindableObject
    {
        private string _imageSource;

        private string _imdbID;

        private string _title;

        private string _year;

        public MovieData(string title, string imageUri, string year, string imdbID)
        {
            this._title = title;
            this.Image = imageUri;
            this._year = year;
            this._imdbID = imdbID;
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

        public string IMdbID
        {
            get => this._imdbID;
            set
            {
                this._imdbID = value;
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

        public string Year
        {
            get => this._title;
            set
            {
                this._year = value;
                this.OnPropertyChanged();
            }
        }
    }
}