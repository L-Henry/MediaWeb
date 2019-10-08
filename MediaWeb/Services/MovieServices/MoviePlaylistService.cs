using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaWeb.Data;
using MediaWeb.Domain.MovieDomain;

namespace MediaWeb.Services.MovieServices
{
    public class MoviePlaylistService : IMoviePlaylistService
    {
        private readonly MediaContext _context;

        public MoviePlaylistService(MediaContext context)
        {
            _context = context;
        }

        public IEnumerable<MoviePlaylist> Get()
        {
            return _context.MoviePlaylist.Where(p => p.Zichtbaar);
        }

        public MoviePlaylist Get(int id) {
            return _context.MoviePlaylist.SingleOrDefault(mp => mp.Id == id);
        }

        public int AantalMoviesInPlaylist(int playlistId) {
            return _context.MoviePlaylistCombo.Where(p => p.MoviePlaylistId == playlistId).Count();
        }

        public int TotaleSpeelduur(int playlistId) {
            var movieIds = _context.MoviePlaylistCombo.Where(p => p.MoviePlaylistId == playlistId).Select(p => p.MovieId).ToList();
            var speelduur = _context.Movies.Where(m => movieIds.Contains(m.Id)).Select(m=>m.Speelduur).Sum();
            return speelduur;
        }

        public MoviePlaylist Insert(MoviePlaylist playlist) {
            _context.MoviePlaylist.Add(playlist);
            _context.SaveChanges();
            return playlist;
        }

        public IEnumerable<MoviePlaylist> GetPlaylistsByUserId(string userId) {
            return _context.MoviePlaylist.Where(pl => pl.UserId == userId);
        }

        public bool CheckIfMovieInPlaylist(int movieId, int playlistId){
            return _context.MoviePlaylistCombo.Any(c => c.MovieId == movieId && c.MoviePlaylistId == playlistId);
        }

        public void AssignMovieToPlaylist(int movieId, int playlistId)
        {
            _context.MoviePlaylistCombo.Add(new MoviePlaylistCombo { MovieId = movieId, MoviePlaylistId = playlistId });
            _context.SaveChanges();
        }

        public void Edit(int id, MoviePlaylist playlist) {
            MoviePlaylist playlistToEdit = Get(id);
            if (playlistToEdit != null)
            {
                playlistToEdit.Naam = playlist.Naam;
                playlistToEdit.Publiek = playlist.Publiek;
                _context.SaveChanges();
            }
        }
    }
}
