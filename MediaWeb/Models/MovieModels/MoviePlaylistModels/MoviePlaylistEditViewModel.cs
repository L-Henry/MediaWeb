using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.MovieModels.MoviePlaylistModels
{
    public class MoviePlaylistEditViewModel
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Publiek { get; set; }
        public string[] Opties = new[] { "Publiek", "Privé" };
        public bool IsCurrentUserOwnerOfPlaylist { get; set; }
    }
}
