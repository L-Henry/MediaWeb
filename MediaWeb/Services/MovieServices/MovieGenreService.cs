using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaWeb.Data;
using MediaWeb.Domain.MovieDomain;
using Microsoft.EntityFrameworkCore;

namespace MediaWeb.Services.MovieServices
{
    public class MovieGenreService : IMovieGenreService
    {
        private readonly MediaContext _context;

        public MovieGenreService(MediaContext context)
        {
            _context = context;
        }

        public IEnumerable<MovieGenre> Get()
        {
            return _context.MovieGenres;
        }

        public MovieGenre Get(int id)
        {
            return _context.MovieGenres.SingleOrDefault(x => x.Id == id);
        }

        public void AssignGenre(Movie movie, string genre)
        {
            _context.GenreMovieCombo.Add(new GenreMovieCombo
            {
                MovieId = movie.Id,
                MovieGenreId = _context.MovieGenres.SingleOrDefault(g=>g.Naam == genre).Id
            });
            _context.SaveChanges();
        }


        public MovieGenre Insert(MovieGenre genre)
        {
            _context.MovieGenres.Add(genre);
            _context.SaveChanges();
            return genre;
        }


        public void Edit(int id, MovieGenre genre)
        {
            MovieGenre genreToEdit = Get(id);
            if (genreToEdit != null)
            {
                genreToEdit.Naam = genre.Naam;
                _context.SaveChanges();
            }
        }

        public IEnumerable<MovieGenre> GetGenresByMovieId(int id)
        {
            var GenreIds = _context.GenreMovieCombo.Where(x => x.MovieId == id).Select(x => x.MovieGenreId).ToList();
            var result = _context.MovieGenres.Where(x => GenreIds.Contains(x.Id));

            return result;
        }

        public void Delete(int id)
        {
            MovieGenre genreToDelete = Get(id);
            _context.MovieGenres.Remove(genreToDelete);
            _context.GenreMovieCombo.RemoveRange(_context.GenreMovieCombo.Where(x => x.MovieGenreId == id));
            _context.SaveChanges();
        }

    }
}
