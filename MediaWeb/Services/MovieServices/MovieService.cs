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
                //movieToEdit.Regisseurs = movie.Regisseurs;
                _context.SaveChanges();
            }
        }

        public IEnumerable<Movie> Get()
        {
            return _context.Movies.Include(m => m.RatingReviews).ThenInclude(r => r.User)
                                  .Include(m => m.UserMovieGezienStatus).ThenInclude(r => r.User)
                                  .Include(m => m.UserMovieGezienStatus).ThenInclude(m => m.MovieGezienStatus)
                                  .Include(m => m.Genres)
                                  .Include(m => m.Regisseurs)
                                  .Include(m => m.MoviePlaylistCombo);  
        }

        public Movie Get(int id)
        {
            return _context.Movies.Include(m => m.RatingReviews).ThenInclude(r=>r.User)
                                  .Include(m => m.UserMovieGezienStatus).ThenInclude(r => r.User)
                                  .Include(m=>m.UserMovieGezienStatus).ThenInclude(m=>m.MovieGezienStatus)
                                  .Include(m => m.Genres)
                                  .Include(m => m.Regisseurs)
                                  .Include(m => m.MoviePlaylistCombo)
                                  .SingleOrDefault(m => m.Id == id);
        }

     

        public IEnumerable<Movie> GetMoviesByGenreId(int genreId)
        {
            return _context.Movies.Where(m => m.Genres.Contains(_context.GenreMovieCombo.SingleOrDefault(mg => mg.MovieGenreId == genreId)));
        }

        public IEnumerable<Movie> GetMoviesByRegisseurId(int regisseurId)
        {
            return _context.Movies.Where(m => m.Regisseurs.Contains(_context.MovieRegisseurCombo.SingleOrDefault(mg => mg.MovieRegisseurId == regisseurId)));
        }
        public IEnumerable<Movie> GetMoviesByPlaylistId(int playlistId)
        {
            return _context.Movies.Where(m => m.MoviePlaylistCombo.Contains(_context.MoviePlaylistCombo.SingleOrDefault(mg => mg.MoviePlaylistId == playlistId)));
        }

        public Movie Insert(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return movie;
        }







        //public IEnumerable<Movie> GetByQuery(string titel, int gezienStatusId, int regisseurId, int ratingOrder, int genreId, string userId)
        //{
        //    IQueryable<Movie> query = _context.Movies.Include(m => m.RatingReviews)
        //                                             .Include(m => m.UserMovieGezienStatus)
        //                                             .Include(m => m.UserMovieFav)
        //                                             .Include(m => m.Genres)
        //                                             .Include(m => m.Regisseurs)
        //                                             .Include(m => m.UserMoviePlaylists);

        //    if (!string.IsNullOrEmpty(titel))
        //    {
        //        if (userId != null && gezienStatusId != 0)
        //        {
        //            if (genreId != 0)
        //            {
        //                if (regisseurId != 0)
        //                {
        //                    query = query.Where(m => m.Titel.Contains(titel)
        //                                    && m.Genres.Contains(_context.GenreMovieCombo.SingleOrDefault(mg => mg.MovieGenreId == genreId))
        //                                    && m.Regisseurs.Contains(_context.MovieRegisseurCombo.SingleOrDefault(mr => mr.MovieRegisseurId == regisseurId))
        //                                    && m.UserMovieGezienStatus.Contains(_context.UserMovieGezienStatus.SingleOrDefault(mgs => mgs.MovieGezienStatusId == gezienStatusId)));
        //                }
        //                else
        //                {
        //                    query = query.Where(m => m.Titel.Contains(titel)
        //                                    && m.Genres.Contains(_context.GenreMovieCombo.SingleOrDefault(mg => mg.MovieGenreId == genreId))
        //                                    && m.UserMovieGezienStatus.Contains(_context.UserMovieGezienStatus.SingleOrDefault(mgs => mgs.MovieGezienStatusId == gezienStatusId)));
        //                }
        //            }
        //            else if (regisseurId != 0)
        //            {
        //                query = query.Where(m => m.Titel.Contains(titel)
        //                                    && m.Regisseurs.Contains(_context.MovieRegisseurCombo.SingleOrDefault(mr => mr.MovieRegisseurId == regisseurId))
        //                                    && m.UserMovieGezienStatus.Contains(_context.UserMovieGezienStatus.SingleOrDefault(mgs => mgs.MovieGezienStatusId == gezienStatusId)));
        //            }
        //            else
        //            {
        //                query = query.Where(m => m.Titel.Contains(titel)
        //                                    && m.UserMovieGezienStatus.Contains(_context.UserMovieGezienStatus.SingleOrDefault(mgs => mgs.MovieGezienStatusId == gezienStatusId)));
        //            }
        //        }
        //        else if (genreId != 0)
        //        {
        //            if (regisseurId != 0)
        //            {
        //                query = query.Where(m => m.Titel.Contains(titel)
        //                                && m.Genres.Contains(_context.GenreMovieCombo.SingleOrDefault(mg => mg.MovieGenreId == genreId))
        //                                && m.Regisseurs.Contains(_context.MovieRegisseurCombo.SingleOrDefault(mr => mr.MovieRegisseurId == regisseurId)));
        //            }
        //            else
        //            {
        //                query = query.Where(m => m.Titel.Contains(titel)
        //                                && m.Genres.Contains(_context.GenreMovieCombo.SingleOrDefault(mg => mg.MovieGenreId == genreId)));
        //            }
        //        }
        //        else if (regisseurId != 0)
        //        {
        //            query = query.Where(m => m.Titel.Contains(titel)
        //                                && m.Regisseurs.Contains(_context.MovieRegisseurCombo.SingleOrDefault(mr => mr.MovieRegisseurId == regisseurId))
        //                                && m.UserMovieGezienStatus.Contains(_context.UserMovieGezienStatus.SingleOrDefault(mgs => mgs.MovieGezienStatusId == gezienStatusId)));
        //        }
        //        else
        //        {
        //            query = query.Where(m => m.Titel.Contains(titel)
        //                                && m.UserMovieGezienStatus.Contains(_context.UserMovieGezienStatus.SingleOrDefault(mgs => mgs.MovieGezienStatusId == gezienStatusId)));
        //        }
        //    }

        //    else if (userId != null && gezienStatusId != 0)
        //    {
        //        if (genreId != 0)
        //        {
        //            if (regisseurId != 0)
        //            {
        //                query = query.Where(m=>m.Genres.Contains(_context.GenreMovieCombo.SingleOrDefault(mg => mg.MovieGenreId == genreId))
        //                                && m.Regisseurs.Contains(_context.MovieRegisseurCombo.SingleOrDefault(mr => mr.MovieRegisseurId == regisseurId))
        //                                && m.UserMovieGezienStatus.Contains(_context.UserMovieGezienStatus.SingleOrDefault(mgs => mgs.MovieGezienStatusId == gezienStatusId)));
        //            }
        //            else
        //            {
        //                query = query.Where(m => m.Genres.Contains(_context.GenreMovieCombo.SingleOrDefault(mg => mg.MovieGenreId == genreId))
        //                                && m.UserMovieGezienStatus.Contains(_context.UserMovieGezienStatus.SingleOrDefault(mgs => mgs.MovieGezienStatusId == gezienStatusId)));
        //            }
        //        }
        //        else if (regisseurId != 0)
        //        {
        //            query = query.Where(m => m.Regisseurs.Contains(_context.MovieRegisseurCombo.SingleOrDefault(mr => mr.MovieRegisseurId == regisseurId))
        //                                && m.UserMovieGezienStatus.Contains(_context.UserMovieGezienStatus.SingleOrDefault(mgs => mgs.MovieGezienStatusId == gezienStatusId)));
        //        }
        //        else
        //        {
        //            query = query.Where(m => m.UserMovieGezienStatus.Contains(_context.UserMovieGezienStatus.SingleOrDefault(mgs => mgs.MovieGezienStatusId == gezienStatusId)));
        //        }
        //    }
        //    else if (genreId != 0)
        //    {
        //        if (regisseurId != 0)
        //        {
        //            query = query.Where(m => m.Genres.Contains(_context.GenreMovieCombo.SingleOrDefault(mg => mg.MovieGenreId == genreId))
        //                            && m.Regisseurs.Contains(_context.MovieRegisseurCombo.SingleOrDefault(mr => mr.MovieRegisseurId == regisseurId)));
        //        }
        //        else
        //        {
        //            query = query.Where(m => m.Genres.Contains(_context.GenreMovieCombo.SingleOrDefault(mg => mg.MovieGenreId == genreId)));
        //        }
        //    }
        //    else if (regisseurId != 0)
        //    {
        //        query = query.Where(m => m.Regisseurs.Contains(_context.MovieRegisseurCombo.SingleOrDefault(mr => mr.MovieRegisseurId == regisseurId)));
        //    }
        //    else
        //    {
        //        ;
        //    }

        //    if (ratingOrder == 1)
        //    {
        //        query = query.OrderBy(m => m.RatingReviews.Select(r => r.Rating));
        //    }
        //    else
        //    {
        //        query = query.OrderByDescending(m => m.RatingReviews.Select(r => r.Rating));

        //    }
        //    var movieQuery = query.ToList();

        //    return movieQuery;
        //}
    }
}
