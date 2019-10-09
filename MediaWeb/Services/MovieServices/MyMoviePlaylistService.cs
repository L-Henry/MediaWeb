using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaWeb.Data;
using MediaWeb.Domain.MovieDomain;

namespace MediaWeb.Services.MovieServices
{
    public class MyMoviePlaylistService : IMyMoviePlaylistService
    {
        private readonly MediaContext _context;

        public IEnumerable<MoviePlaylist> GetByUserId(string userId)
        {
            var playlists = _context.MoviePlaylist.Where(pl => pl.UserId == userId);
            return playlists;
        }
    }
}
