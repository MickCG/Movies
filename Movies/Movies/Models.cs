namespace Movies
{
    using System.Collections.Generic;

    public class Search
    {
        public string imdbID { get; set; }

        public string Poster { get; set; }

        public string Title { get; set; }

        public string Type { get; set; }

        public string Year { get; set; }
    }

    public class RootObject
    {
        public string Response { get; set; }

        public List<Search> Search { get; set; }

        public string totalResults { get; set; }
    }
}