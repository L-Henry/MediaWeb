using MediaWeb.Domain.MovieDomain;
using MediaWeb.Models.MovieModels.MovieRegisseurModels;
using MediaWeb.Services.MovieServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Controllers.MovieControllers
{
    public class MovieRegisseurController : Controller
    {
        private readonly IMovieRegisseurService _movieRegisseurService;
        private readonly IMovieService _movieService;


        public MovieRegisseurController(IMovieRegisseurService movieRegisseurService, IMovieService movieService)
        {
            _movieRegisseurService = movieRegisseurService;
            _movieService = movieService;
        }

        //[Authorize]
        public IActionResult Index()
        {
            List<MovieRegisseurListViewModel> listVM = new List<MovieRegisseurListViewModel>();
            IEnumerable<MovieRegisseur> movieGenresFromDb = _movieRegisseurService.Get();

            foreach (var genre in movieGenresFromDb)
            {
                listVM.Add(new MovieRegisseurListViewModel
                {
                    Id = genre.Id,
                    Naam = genre.Naam
                });
            }

            MovieRegisseurIndexViewModel vm = new MovieRegisseurIndexViewModel
            {
                ListVM = listVM
            };

            return View(vm);
        }

        //[Authorize]
        [HttpPost]
        public IActionResult Create(MovieRegisseurCreateViewModel model)
        {
            if (!TryValidateModel(model))
            {
                return RedirectToAction("Index");
            }
            MovieRegisseur movieRegisseurToCreate = new MovieRegisseur
            {
                Naam = model.Naam
            };

            _movieRegisseurService.Insert(movieRegisseurToCreate);

            return RedirectToAction("Index");
        }

        //[Authorize]
        [HttpPost]
        public IActionResult Edit(int id, MovieRegisseurEditViewModel model)
        {
            if (!TryValidateModel(model))
            {
                return RedirectToAction("Index");
            }
            MovieRegisseur movieRegisseurToEdit = new MovieRegisseur
            {
                Id = id,
                Naam = model.Naam
            };

            _movieRegisseurService.Edit(id, movieRegisseurToEdit);

            return RedirectToAction("Index");
        }

        //[Authorize]
        public IActionResult Delete(int id)
        {
            MovieRegisseur movieGenreToDelete = _movieRegisseurService.Get(id);
            IEnumerable<Movie> moviesFromDb = _movieService.GetMoviesByRegisseurId(id);
            List<MovieRegisseurMoviesImpactedByDeleteViewModel> impactedMovies = new List<MovieRegisseurMoviesImpactedByDeleteViewModel>();
            foreach (var mov in moviesFromDb)
            {
                impactedMovies.Add(new MovieRegisseurMoviesImpactedByDeleteViewModel
                {
                    Id = mov.Id,
                    Titel = mov.Titel
                });
            }

            MovieRegisseurDeleteViewModel vm = new MovieRegisseurDeleteViewModel
            {
                Id = id,
                Naam = movieGenreToDelete.Naam,
                ImpactedMovies = impactedMovies
            };
            return View(vm);
        }

        //[Authorize]
        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            _movieRegisseurService.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
