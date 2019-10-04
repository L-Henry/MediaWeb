using MediaWeb.Domain.MovieDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Services.MovieServices
{
    public interface IMoviePlaylistService
    {
        IEnumerable<MoviePlaylist> Get();
        int AantalMoviesInPlaylist(int playlistId);
        int TotaleSpeelduur(int playlistId);
        MoviePlaylist Insert(MoviePlaylist playlist);
        MoviePlaylist Get(int id);
        IEnumerable<MoviePlaylist> GetPlaylistsByUserId(string userId);

        bool CheckIfMovieInPlaylist(int movieId, int playlistId);
        void AssignMovieToPlaylist(int movieId, int playlistId);
    }
}
