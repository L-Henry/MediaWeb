using MediaWeb.Domain.MovieDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Services.MovieServices
{
    public interface IMovieGenreService
    {
        IEnumerable<MovieGenre> Get();
        
        MovieGenre Get(int id);
        MovieGenre Insert(MovieGenre genre);
        void Edit(int id, MovieGenre genre);
        void Delete(int id);
        void AssignGenre(Movie movie, string genre);
        IEnumerable<MovieGenre> GetGenresByMovieId(int id);

    }
}
