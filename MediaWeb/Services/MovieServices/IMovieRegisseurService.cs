using MediaWeb.Domain.MovieDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Services.MovieServices
{
    public interface IMovieRegisseurService
    {
        IEnumerable<MovieRegisseur> Get();
      
        MovieRegisseur Get(int id);
        MovieRegisseur Insert(MovieRegisseur regisseur);
        void Edit(int id, MovieRegisseur regisseur);
        void Delete(int id);
        MovieRegisseur HandleRegisseurCreate(Movie movie, string naam);
        void AssignRegisseur(Movie movie, MovieRegisseur movieRegisseur);
        IEnumerable<MovieRegisseur> GetRegisseursByMovieId(int id);

    }
}
