using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaWeb.Data;
using MediaWeb.Domain.MovieDomain;

namespace MediaWeb.Services.MovieServices
{
    public class MovieRegisseurService : IMovieRegisseurService
    {
        private readonly MediaContext _context;

        public MovieRegisseurService(MediaContext context)
        {
            _context = context;
        }

        public MovieRegisseur HandleRegisseurCreate(Movie movie, string naam)
        {
            MovieRegisseur regisseur = new MovieRegisseur();

            if (_context.MovieRegisseur.Any(x=>x.Naam.ToLower() == naam.ToLower()))
            {
                regisseur = _context.MovieRegisseur.SingleOrDefault(r => r.Naam.ToLower() == naam.ToLower());
                AssignRegisseur(movie, regisseur);
            }
            else
            {
                regisseur.Naam = naam;
                Insert(regisseur);
                AssignRegisseur(movie, regisseur);
            }
            return regisseur;
        }

        public void AssignRegisseur(Movie movie, MovieRegisseur regisseur) {
            _context.MovieRegisseurCombo.Add(new MovieRegisseurCombo
            {
                MovieId = movie.Id,
                MovieRegisseurId = regisseur.Id
            });
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            MovieRegisseur regisseurToDelete = Get(id);
            _context.MovieRegisseur.Remove(regisseurToDelete);
            _context.MovieRegisseurCombo.RemoveRange(_context.MovieRegisseurCombo.Where(x => x.MovieRegisseurId == id));
            _context.SaveChanges();
        }

        public void Edit(int id, MovieRegisseur regisseur)
        {
            MovieRegisseur regisseurToEdit = Get(id);
            if (regisseurToEdit != null)
            {
                regisseurToEdit.Naam = regisseur.Naam;
                _context.SaveChanges();
            }
        }

        public IEnumerable<MovieRegisseur> Get()
        {
            return _context.MovieRegisseur;
        }

        public MovieRegisseur Get(int id)
        {
            return _context.MovieRegisseur.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<MovieRegisseur> GetRegisseursByMovieId(int id)
        {
            var GenreIds = _context.MovieRegisseurCombo.Where(x => x.MovieId == id).Select(x => x.MovieRegisseurId).ToList();
            var result = _context.MovieRegisseur.Where(x => GenreIds.Contains(x.Id));

            return result;
        }

        public MovieRegisseur Insert(MovieRegisseur regisseur)
        {
            _context.MovieRegisseur.Add(regisseur);
            _context.SaveChanges();
            return regisseur;
        }


    }
}
