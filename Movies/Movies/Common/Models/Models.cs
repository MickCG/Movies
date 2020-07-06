// ***********************************************************************
// Assembly         : Movies
// Author           : mick_
// Created          : 07-06-2020
//
// Last Modified By : mick_
// Last Modified On : 07-05-2020
// ***********************************************************************
// <copyright file="Models.cs" Application="Movies">
//     Copyright (c) Happy Troll Computing. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Movies.Common.Models
{
    using System.Collections.Generic;

    public class BaseMovieInformation
    {
        public string ImdbID { get; set; }

        public string Poster { get; set; }

        public string Title { get; set; }

        public string Type { get; set; }

        public string Year { get; set; }
    }

    public class ListOfMovies
    {
        public string Response { get; set; }

        public List<BaseMovieInformation> Search { get; set; }

        public string TotalResults { get; set; }
    }
}