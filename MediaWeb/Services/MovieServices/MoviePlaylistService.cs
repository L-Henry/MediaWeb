using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaWeb.Data;
using MediaWeb.Domain.MovieDomain;
using Microsoft.EntityFrameworkCore;

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
            return _context.MoviePlaylist.Include(pl => pl.User)
                                         .Where(p => p.Zichtbaar);
        }

        public MoviePlaylist Get(int id) {
            return _context.MoviePlaylist.Include(pl=>pl.User)
                                         .SingleOrDefault(mp => mp.Id == id);
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

        public void Delete(int playlistId) {
            MoviePlaylist playlistToDelete = Get(playlistId);
            _context.MoviePlaylist.Remove(playlistToDelete);
            _context.MoviePlaylistCombo.RemoveRange(_context.MoviePlaylistCombo.Where(pl => pl.MoviePlaylistId == playlistId));
            _context.SaveChanges();
        }
    }
}
