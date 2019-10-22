using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.MovieModels.MoviePlaylistModels
{
    public class MoviePlaylistCreateViewModel
    {
        public string Naam { get; set; }
        public string Publiek { get; set; }
        public string[] Opties = new[] { "Publiek", "Privé" };
    }
}
