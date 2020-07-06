namespace Movies.Common.Network
{
    public static class ApiConstants
    {
        public static string GetApiUri(string search)
        {
            return $"https://omdbapi.com/?apikey=1d2f62f7&s={search}&page=1";
        }
    }
}