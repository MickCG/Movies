namespace Movies.Common.Models
{
    using System.Collections.Generic;

    public class ListOfMovies
    {
        public string Response { get; set; }

        public List<BaseMovieInformation> Search { get; set; }

        public string TotalResults { get; set; }
    }
}