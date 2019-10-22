using MediaWeb.Domain.MovieDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.MovieModels.MovieRegisseurModels
{
    public class MovieRegisseurDeleteViewModel
    {
        public int Id { get; set; }
        public string Naam { get; set; }

        public IEnumerable<MovieRegisseurMoviesImpactedByDeleteViewModel> ImpactedMovies { get; set; }
    }
}
