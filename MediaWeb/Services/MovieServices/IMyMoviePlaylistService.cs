using MediaWeb.Domain.MovieDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Services.MovieServices
{
    public interface IMyMoviePlaylistService
    {
        IEnumerable<MoviePlaylist> GetByUserId(string userId);

    }
}
