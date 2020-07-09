namespace Movies.Common.Converters
{
    using System;
    using System.Globalization;

    using Xamarin.Forms;

    public class BoolToFavoriteImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value) return "fullheart.png";

            return "emptyHeart.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}