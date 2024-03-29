﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.MovieModels.MovieGenreModels
{
    public class MovieGenreDeleteViewModel
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public IEnumerable<MovieGenreMoviesImpactedByDeleteViewModel> ImpactedMovies { get; set; }
    }
}
