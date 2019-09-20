using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.Movie
{
    public class UserMoviePlaylist
    {
        public int MovieId { get; set; }

        public string UserId { get; set; }

        public int MoviePlaylistId { get; set; }

    }
}
