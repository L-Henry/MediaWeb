using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.MyMediaModels
{
    public class MyMediaMoviePlaylistsViewModel
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public int Aantal { get; set; }
        public int Speelduur { get; set; }
        public bool Publiek { get; set; }
    }
}
