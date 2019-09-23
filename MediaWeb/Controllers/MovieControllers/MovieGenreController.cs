using MediaWeb.Domain.MovieDomain;
using MediaWeb.Models.MovieModels.MovieGenreModels;
using MediaWeb.Services.MovieServices;
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

        public MovieGenreController(IMovieGenreService movieGenreService)
        {
            _movieGenreService = movieGenreService;
        }

        //[Authorize]
        public IActionResult Index()
        {
            List<MovieGenreListViewModel> vm = new List<MovieGenreListViewModel>();
            IEnumerable<MovieGenre> movieGenresFromDb = _movieGenreService.Get();
            foreach (var genre in movieGenresFromDb)
            {
                vm.Add(new MovieGenreListViewModel
                {
                    Id = genre.Id,
                    Naam = genre.Naam
                });
            }
            return View(vm);
        }

        //[Authorize]
        public IActionResult Create() {
            return View();
        }

        //[Authorize]
        [HttpPost]
        public IActionResult Create(MovieGenreCreateViewModel model) {
            if (!TryValidateModel(model))
            {
                return View();
            }
            MovieGenre movieGenreToCreate = new MovieGenre {
                Naam = model.Naam
            };

            _movieGenreService.Insert(movieGenreToCreate);

            return RedirectToAction("Index");
        }

        //[Authorize]
        public IActionResult Edit() {
            return View();

        }



    }
}
