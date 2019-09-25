using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.MovieModels.MovieGenreModels
{
    public class MovieGenreIndexViewModel
    {
        public string Naam { get; set; }
        public IEnumerable<MovieGenreListViewModel> ListVM { get; set; }

    }
}
