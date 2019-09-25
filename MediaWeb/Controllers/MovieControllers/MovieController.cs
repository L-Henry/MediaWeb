using MediaWeb.Domain.MovieDomain;
using MediaWeb.Models.MovieModels.MovieModels;
using MediaWeb.Services.MovieServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MediaWeb.Controllers.MovieControllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IMovieRegisseurService _regisseurService;
        private readonly IMovieGenreService _genreService;
        private readonly IMovieGenreService _GezienService;



        public MovieController(IMovieService movieService, IMovieRegisseurService regisseurService, IMovieGenreService genreService)
        {
            _movieService = movieService;
            _regisseurService = regisseurService;
            _genreService = genreService;
        }


        public IActionResult Index()
        {
            List<MovieListViewModel> movies = new List<MovieListViewModel>();
            IEnumerable<Movie> moviesFromDb = _movieService.Get();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            foreach (var movie in moviesFromDb)
            {
                string regisseurs = string.Join(",", _regisseurService.GetRegisseursByMovieId(movie.Id).Select(x => x.Naam));
                string genres = string.Join(",", _genreService.GetGenresByMovieId(movie.Id).Select(x => x.Naam));

                int ratingAvg = movie.RatingReviews.Where(rat => rat.MovieId == movie.Id && rat.Rating > -1).Count() != 0 ?
                    movie.RatingReviews.Where(rat => rat.MovieId == movie.Id && rat.Rating > -1).Select(r => r.Rating).Sum() / movie.RatingReviews.Where(rat => rat.MovieId == movie.Id && rat.Rating > -1).Count() : -1;

                int aantalGezien = movie.UserMovieGezienStatus.Any(s => s.MovieGezienStatus != null) ?
                    movie.UserMovieGezienStatus.Where(s => s.MovieId == movie.Id && s.MovieGezienStatus != null && s.MovieGezienStatusId == 2).Count() : 0;

                int heeftGezien = userId != null && movie.UserMovieGezienStatus.Any(s => s.UserId == userId && s.MovieGezienStatus != null) ?
                    movie.UserMovieGezienStatus.SingleOrDefault(s => s.MovieId == movie.Id && s.UserId == userId).MovieGezienStatusId : 1;

                movies.Add(new MovieListViewModel
                {
                    Id = movie.Id,
                    Titel = movie.Titel,
                    Beschrijving = movie.Beschrijving,
                    Regisseurs = regisseurs,
                    Genres = genres,
                    AantalGezien = aantalGezien,
                    HeeftGezien = heeftGezien,
                    Rating = ratingAvg
                });
            }
            MovieFilterListViewModel model = new MovieFilterListViewModel {
                Movies = movies
            };
            return View(model);
        }

        //[Authorize]
        public IActionResult Create() {
            List<MovieGenreListViewModel> list = new List<MovieGenreListViewModel>();
            foreach (var item in _genreService.Get())
            {
                list.Add(new MovieGenreListViewModel() { Naam = item.Naam });
            };
            MovieCreateViewModel model = new MovieCreateViewModel()
            {
                GenreList = list
            };
            return View(model);
        }

        //[Authorize]
        [HttpPost]
        public IActionResult Create(MovieCreateViewModel model) {
            if (!TryValidateModel(model))
            {
                return View();
            }

            Movie movieToAdd = new Movie
            {
                Titel = model.Titel,
                Beschrijving = model.Beschrijving,
                Speelduur = model.Speelduur
            };
            _movieService.Insert(movieToAdd);

            foreach (var genre in model.GenreList)
            {
                if (genre.Checked)
                {
                    _genreService.AssignGenre(movieToAdd, genre.Naam);
                }
            }
            foreach (var reg in model.RegisseurList)
            {
                _regisseurService.HandleRegisseurCreate(movieToAdd, reg);
            }

            return RedirectToAction("Details", new { id = movieToAdd.Id });
        }

        public IActionResult Details(int id) {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            Movie movieFromDb = _movieService.Get(id);

            string regisseurs = string.Join(",", _regisseurService.GetRegisseursByMovieId(movieFromDb.Id).Select(x => x.Naam));
            string genres = string.Join(",", _genreService.GetGenresByMovieId(movieFromDb.Id).Select(x => x.Naam));

            int ratingAvg = movieFromDb.RatingReviews.Where(rat => rat.MovieId == movieFromDb.Id && rat.Rating > -1).Count() != 0 ?
                    movieFromDb.RatingReviews.Where(rat => rat.MovieId == movieFromDb.Id && rat.Rating > -1).Select(r => r.Rating).Sum()
                    / movieFromDb.RatingReviews.Where(rat => rat.MovieId == movieFromDb.Id && rat.Rating > -1).Count() : -1;

            int aantalGezien = movieFromDb.UserMovieGezienStatus.Any(s => s.MovieGezienStatus != null) ?
                    movieFromDb.UserMovieGezienStatus.Where(s => s.MovieId == movieFromDb.Id && s.MovieGezienStatus != null && s.MovieGezienStatusId == 2).Count() : 0;

            int aantalWilZien = movieFromDb.UserMovieGezienStatus.Any(s => s.MovieGezienStatus != null) ?
                    movieFromDb.UserMovieGezienStatus.Where(s => s.MovieId == movieFromDb.Id && s.MovieGezienStatus != null && s.MovieGezienStatusId == 3).Count() : 0;

            int heeftGezien = userId != null && movieFromDb.UserMovieGezienStatus.Any(s => s.UserId == userId && s.MovieGezienStatus != null) ?
                    movieFromDb.UserMovieGezienStatus.SingleOrDefault(s => s.MovieId == movieFromDb.Id && s.UserId == userId).MovieGezienStatusId : 1;

            int eigenRating = userId != null && movieFromDb.RatingReviews.Any(rr => rr.UserId == userId) /*movieFromDb.RatingReviews.Count != 0*/ ?
                movieFromDb.RatingReviews.SingleOrDefault(r => r.MovieId == movieFromDb.Id && r.UserId == userId).Rating : -1;

            List<SelectListItem> heeftGezienSelectList = new List<SelectListItem>();
            foreach (var gezienStatus in _GezienService.Get())
            {
                heeftGezienSelectList.Add(new SelectListItem { Value = gezienStatus.Id.ToString(), Text = gezienStatus.Naam });
            }
            List<SelectListItem> eigenRatingSelectList = new List<SelectListItem>();
            eigenRatingSelectList.Add(new SelectListItem { Value = "-1", Text = "Geef rating" });
            for (var i = 0; i <= 10; i++)
            {
                eigenRatingSelectList.Add(new SelectListItem { Value = i.ToString(), Text = i.ToString() });
            }
            List<MovieRatingReviewViewModel> ratingReviewList = new List<MovieRatingReviewViewModel>();
            foreach (var rr in movieFromDb.RatingReviews.Where(r => r.MovieId == id).ToList())
            {
                ratingReviewList.Add(new MovieRatingReviewViewModel
                {
                    Id = rr.MovieId,
                    Rating = rr.Rating,
                    Review = rr.Review,
                    UserName = rr.User.UserName
                });
            }

            MovieDetailsViewModel movieVM = new MovieDetailsViewModel()
            {
                Id = movieFromDb.Id,
                Titel = movieFromDb.Titel,
                //FotoFile = movieFromDb.Foto,
                Genres = genres,
                Regisseurs = regisseurs,
                Rating = ratingAvg,
                EigenRating = eigenRating,
                EigenRatingSelectList = eigenRatingSelectList,
                AantalGezien = aantalGezien,
                AantalWilZien = aantalWilZien,
                HeeftGezienSelectList = heeftGezienSelectList,
                HeeftGezien = heeftGezien,
                RatingReview = ratingReviewList
            };
            return View(movieVM);
        }

    }
}
