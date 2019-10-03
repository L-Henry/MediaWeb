using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaWeb.Domain;
using MediaWeb.Domain.MovieDomain;

namespace MediaWeb.Services.MovieServices
{
    public interface IMovieService
    {
        IEnumerable<Movie> Get();
        IEnumerable<Movie> GetMoviesByGenreId(int genreId);
        IEnumerable<Movie> GetMoviesByRegisseurId(int regisseurId);
        IEnumerable<Movie> GetMoviesByPlaylistId(int playlistId);
        IEnumerable<Movie> GetByQuery(string titel, int gezienStatusId, int regisseurId, int ratingOrder, int genreId, string userId);
        Movie Get(int id);
        Movie Insert(Movie movie);
        void Edit(int id, Movie movie);
        void Delete(int id);

    }
}
