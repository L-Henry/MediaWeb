using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MediaWeb.Models.MovieModels.MoviePlaylistModels
{
    public class MoviePlaylistMoviesListViewModel
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public int Rating { get; set; }
        public int AantalGezien { get; set; }
        public int Speelduur { get; set; }

    }
}