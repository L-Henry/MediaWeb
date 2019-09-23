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
        Movie Get(int id);
        Movie Insert(Movie movie);
        Movie Edit(int id, Movie movie);
        void Delete(int id);

    }
}
