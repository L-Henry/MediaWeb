using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.MovieModels.MoviePlaylistModels
{
    public class MoviePlaylistDetailsListView
    {
        public IEnumerable<MoviePlaylistMoviesListViewModel> Movies { get; set; }
        public int Id { get; set; }
        public string Naam { get; set; }
        public int Speelduur { get; set; }
        public int Aantal { get; set; }
        public string  Username { get; set; }

    }
}
