using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaWeb.Data;
using MediaWeb.Domain.MovieDomain;
using Microsoft.EntityFrameworkCore;

namespace MediaWeb.Services.MovieServices
{
    public class MovieService : IMovieService
    {
        private readonly MediaContext _context;

        public MovieService(MediaContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            Movie movieToDelete = Get(id);
            _context.Movies.Remove(movieToDelete);
            _context.MovieRegisseurCombo.RemoveRange(_context.MovieRegisseurCombo.Where(m => m.MovieId == id));
            _context.GenreMovieCombo.RemoveRange(_context.GenreMovieCombo.Where(m => m.MovieId == id));
            _context.SaveChanges();
        }

        public void Edit(int id, Movie movie)
        {
            Movie movieToEdit = Get(id);
            if (movieToEdit != null)
            {
                movieToEdit.Titel = movie.Titel;
                movieToEdit.Beschrijving = movie.Beschrijving;
                movieToEdit.Genres = movie.Genres;
                movieToEdit.Regisseurs = movie.Regisseurs;
                _context.SaveChanges();
            }
        }

        public IEnumerable<Movie> Get()
        {
            return _context.Movies.Include(m=>m.RatingReviews)
                                  .Include(m=>m.UserMovieGezienStatus);
        }

        public Movie Get(int id)
        {
            return _context.Movies.SingleOrDefault(m => m.Id == id);
        }

        public IEnumerable<Movie> GetMoviesByGenreId(int genreId)
        {
            return _context.Movies.Where(m => m.Genres.Contains(_context.GenreMovieCombo.SingleOrDefault(mg => mg.MovieGenreId == genreId)));
        }

        public IEnumerable<Movie> GetMoviesByRegisseurId(int regisseurId)
        {
            return _context.Movies.Where(m => m.Regisseurs.Contains(_context.MovieRegisseurCombo.SingleOrDefault(mg => mg.MovieRegisseurId == regisseurId)));
        }

        public Movie Insert(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return movie;
        }
    }
}
