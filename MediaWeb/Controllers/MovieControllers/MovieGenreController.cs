using MediaWeb.Domain.MovieDomain;
using MediaWeb.Models.MovieModels.MovieGenreModels;
using MediaWeb.Services.MovieServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Controllers.MovieControllers
{
    public class MovieGenreController : Controller
    {
        private readonly IMovieGenreService _movieGenreService;
        private readonly IMovieService _movieService;


        public MovieGenreController(IMovieGenreService movieGenreService, IMovieService movieService)
        {
            _movieGenreService = movieGenreService;
            _movieService = movieService;
        }

        [Authorize]
        public IActionResult Index()
        {
            List<MovieGenreListViewModel> listVM = new List<MovieGenreListViewModel>();
            IEnumerable<MovieGenre> movieGenresFromDb = _movieGenreService.Get();

            foreach (var genre in movieGenresFromDb)
            {
                listVM.Add(new MovieGenreListViewModel
                {
                    Id = genre.Id,
                    Naam = genre.Naam
                });
            }

            MovieGenreIndexViewModel vm = new MovieGenreIndexViewModel {
                ListVM = listVM
            };

            return View(vm);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(MovieGenreCreateViewModel model) {
            if (!TryValidateModel(model))
            {
                return RedirectToAction("Index");
            }
            MovieGenre movieGenreToCreate = new MovieGenre {
                Naam = model.Naam
            };

            _movieGenreService.Insert(movieGenreToCreate);

            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(int id, MovieGenreEditViewModel model) {
            if (!TryValidateModel(model))
            {
                return RedirectToAction("Index");
            }
            MovieGenre movieGenreToEdit = new MovieGenre
            {
                Id = id,
                Naam = model.Naam
            };

            _movieGenreService.Edit(id, movieGenreToEdit);

            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Delete(int id) {
            MovieGenre movieGenreToDelete = _movieGenreService.Get(id);
            IEnumerable<Movie> moviesFromDb = _movieService.GetMoviesByGenreId(id);
            List<MovieGenreMoviesImpactedByDeleteViewModel> impactedMovies = new List<MovieGenreMoviesImpactedByDeleteViewModel>();
            foreach (var mov in moviesFromDb)
            {
                impactedMovies.Add(new MovieGenreMoviesImpactedByDeleteViewModel
                {
                    Id = mov.Id,
                    Titel = mov.Titel
                });
            }

            MovieGenreDeleteViewModel vm = new MovieGenreDeleteViewModel
            {
                Id = id,
                Naam = movieGenreToDelete.Naam,
                ImpactedMovies = impactedMovies
            };
            return View(vm);
        }

        [Authorize]
        [HttpPost]
        public IActionResult ConfirmDelete(int id) {
            _movieGenreService.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
