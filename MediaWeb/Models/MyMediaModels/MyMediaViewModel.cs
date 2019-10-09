using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.MyMediaModels
{
    public class MyMediaViewModel
    {
        public IEnumerable<MyMediaMoviesViewModel> MyMovies { get; set; }
        public IEnumerable<MyMediaMoviePlaylistsViewModel> MyPlaylists { get; set; }

    }
}
