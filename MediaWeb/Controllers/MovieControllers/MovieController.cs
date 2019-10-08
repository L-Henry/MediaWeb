using MediaWeb.Domain.MovieDomain;
using MediaWeb.Models.MovieModels.MovieModels;
using MediaWeb.Services.MovieServices;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IMovieGezienStatusService _GezienStatusService;
        private readonly IMovieRatingReviewService _RatingReviewService;
        private readonly IMoviePlaylistService _playlistService;



        public MovieController(IMovieService movieService, IMovieRegisseurService regisseurService, IMovieGenreService genreService, 
            IMovieGezienStatusService gezienStatusService, IMovieRatingReviewService ratingReviewService, IMoviePlaylistService playlistService)
        {
            _movieService = movieService;
            _regisseurService = regisseurService;
            _genreService = genreService;
            _GezienStatusService = gezienStatusService;
            _RatingReviewService = ratingReviewService;
            _playlistService = playlistService;
        }


        public IActionResult Index()
        {
            List<MovieListViewModel> movies = new List<MovieListViewModel>();
            IEnumerable<Movie> moviesFromDb = _movieService.Get();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            foreach (var movie in moviesFromDb)
            {
                string regisseurs = _regisseurService.GetRegisseursByMovieId(movie.Id).Count() != 0 ? string.Join(",", _regisseurService.GetRegisseursByMovieId(movie.Id).Select(x => x.Naam)) : "Geen regisseur";
                string genres = _genreService.GetGenresByMovieId(movie.Id) != null ? string.Join(",", _genreService.GetGenresByMovieId(movie.Id).Select(x => x.Naam)) : "Geen genres";

                int ratingAvg = movie.RatingReviews != null && movie.RatingReviews.Where(r => r.MovieId == movie.Id).Select(r => r.Rating).Count() != 0 ?
                   movie.RatingReviews.Where(rat => rat.MovieId == movie.Id && rat.Rating > -1).Select(r => r.Rating).Sum()
                   / movie.RatingReviews.Where(rat => rat.MovieId == movie.Id && rat.Rating > -1).Count() : -1;

                int aantalGezien = movie.UserMovieGezienStatus != null ?
                        movie.UserMovieGezienStatus.Where(s => s.MovieId == movie.Id && s.MovieGezienStatus != null && s.MovieGezienStatusId == 2).Count() : 0;

                int heeftGezien = userId != null && movie.UserMovieGezienStatus.Any(s => s.UserId == userId) ?
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
                    Rating = ratingAvg,
                });
            }

            List<SelectListItem> GezienStatusList = new List<SelectListItem>();
            foreach (var status in _GezienStatusService.Get())
            {
                GezienStatusList.Add(new SelectListItem { Value = status.Id.ToString(), Text = status.Status });
            }
            List<SelectListItem> RatingList = new List<SelectListItem> { new SelectListItem {Value = "0", Text = "Geen selectie"},
                                                                         new SelectListItem { Value = "1", Text = "Up"},
                                                                         new SelectListItem { Value = "2", Text = "Down"} };
            List<SelectListItem> genreList = new List<SelectListItem>();
            genreList.Add(new SelectListItem { Value = "0", Text = "Selecteer genre" });
            foreach (var gen in _genreService.Get())
            {
                genreList.Add(new SelectListItem { Value = gen.Id.ToString(), Text = gen.Naam });
            }
            List<SelectListItem> regisseurList = new List<SelectListItem>();
            regisseurList.Add(new SelectListItem { Value = "0", Text = "Selecteer regisseur" });
            foreach (var reg in _regisseurService.Get())
            {
                regisseurList.Add(new SelectListItem { Value = reg.Id.ToString(), Text = reg.Naam });
            }

            MovieFilterListViewModel model = new MovieFilterListViewModel
            {
                Movies = movies,
                RegisseurList = regisseurList,
            };
            return View(model);
        }

        //[HttpGet]
        //public IActionResult Index(string titel, int gezienStatusId, int regisseurId, int ratingUpDown, int genreId, bool review) {
        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        //    List<MovieListViewModel> movies = new List<MovieListViewModel>();
        //    MovieFilterListViewModel model = new MovieFilterListViewModel();
        //    _movieService.GetByQuery(titel, gezienStatusId, regisseurId, ratingUpDown, genreId, userId);

        //    return View(model);
        //}
    

        [Authorize]
        public IActionResult Create() {
            List<MovieGenreListViewModel> genreList = new List<MovieGenreListViewModel>();
            foreach (var genre in _genreService.Get())
            {
                genreList.Add(new MovieGenreListViewModel() { Naam = genre.Naam });
            };
            List<string> regList = new List<string>();
            foreach (var reg in _regisseurService.Get())
            {
                regList.Add(reg.Naam);
            }
            MovieCreateViewModel model = new MovieCreateViewModel()
            {
                GenreList = genreList,
                RegisseurList = regList
            };
            return View(model);
        }

        [Authorize]
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
            //List<string> regisseurList = model.Regisseurs.ToList();
            //foreach (var reg in regisseurList)
            //{
            //    _regisseurService.HandleRegisseurCreate(movieToAdd, reg);
            //}
            _regisseurService.HandleRegisseurCreate(movieToAdd, model.Regisseurs);

            return RedirectToAction("Details", new { movieId = movieToAdd.Id });
        }

        public IActionResult Details(int movieId) {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            Movie movieFromDb = _movieService.Get(movieId);

            string regisseurs = string.Join(",", _regisseurService.GetRegisseursByMovieId(movieFromDb.Id).Select(x => x.Naam));
            IEnumerable<string> genresList = _genreService.GetGenresByMovieId(movieFromDb.Id).Select(x => x.Naam);
            string genres = string.Join(",", genresList);

            int ratingAvg = movieFromDb.RatingReviews != null && movieFromDb.RatingReviews.Where(r=>r.MovieId == movieId).Select(r=>r.Rating).Count() != 0 ?
                    movieFromDb.RatingReviews.Where(rat => rat.MovieId == movieFromDb.Id && rat.Rating > -1).Select(r => r.Rating).Sum()
                    / movieFromDb.RatingReviews.Where(rat => rat.MovieId == movieFromDb.Id && rat.Rating > -1).Count() : -1;

            int aantalGezien = movieFromDb.UserMovieGezienStatus != null ?
                    movieFromDb.UserMovieGezienStatus.Where(s => s.MovieId == movieFromDb.Id && s.MovieGezienStatus != null && s.MovieGezienStatusId == 2).Count() : 0;

            int aantalWilZien = movieFromDb.UserMovieGezienStatus != null ?
                    movieFromDb.UserMovieGezienStatus.Where(s => s.MovieId == movieFromDb.Id && s.MovieGezienStatus != null && s.MovieGezienStatusId == 3).Count() : 0;

            int heeftGezien = userId != null && movieFromDb.UserMovieGezienStatus.Any(s => s.UserId == userId) ?
                    movieFromDb.UserMovieGezienStatus.SingleOrDefault(s => s.MovieId == movieFromDb.Id && s.UserId == userId).MovieGezienStatusId : 1;

            int eigenRating = userId != null && movieFromDb.RatingReviews.Any(rr => rr.UserId == userId) /*movieFromDb.RatingReviews.Count != 0*/ ?
                movieFromDb.RatingReviews.SingleOrDefault(r => r.MovieId == movieFromDb.Id && r.UserId == userId).Rating : -1;

            List<SelectListItem> heeftGezienSelectList = new List<SelectListItem>();
            foreach (var gezienStatus in _GezienStatusService.Get())
            {
                heeftGezienSelectList.Add(new SelectListItem { Value = gezienStatus.Id.ToString(), Text = gezienStatus.Status });
            }
            List<SelectListItem> eigenRatingSelectList = new List<SelectListItem>();
            eigenRatingSelectList.Add(new SelectListItem { Value = "-1", Text = "Geef rating" });
            for (var i = 0; i <= 10; i++)
            {
                eigenRatingSelectList.Add(new SelectListItem { Value = i.ToString(), Text = i.ToString() });
            }
            List<MovieRatingReviewViewModel> ratingReviewList = new List<MovieRatingReviewViewModel>();
            if (movieFromDb.RatingReviews != null)
            {
                foreach (var rr in movieFromDb.RatingReviews.Where(r => r.MovieId == movieId).ToList())
                {
                    ratingReviewList.Add(new MovieRatingReviewViewModel
                    {
                        Id = rr.MovieId,
                        Rating = rr.Rating,
                        Review = rr.Review,
                        UserName = rr.User.UserName
                    });
                }
            }

            List<SelectListItem> playlistsFromUser = new List<SelectListItem>();
            playlistsFromUser.Add(new SelectListItem { Text = "Kies playlist om aan film aan toe te voegen" });
            foreach (var pl in _playlistService.GetPlaylistsByUserId(userId))
            {
                if (!_playlistService.CheckIfMovieInPlaylist(movieFromDb.Id, pl.Id))
                {
                    playlistsFromUser.Add(new SelectListItem { Value = pl.Id.ToString(), Text = pl.Naam });
                }
            }
            if (playlistsFromUser.Count == 0)
            {
                playlistsFromUser.Clear();
                playlistsFromUser.Add(new SelectListItem { Text = "Geen beschikbare playlists om aan toe te voegen." });
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
                RatingReview = ratingReviewList,
                Playlists = playlistsFromUser
            };
            return View(movieVM);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Details(MovieDetailsViewModel model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _GezienStatusService.AssignGezienStatus(model.Id, userId, model.HeeftGezien);
            if (model.EigenRating > -1)
            {
                _RatingReviewService.AssignRatingReview(model.Id, userId, model.EigenRating);
            }
            return RedirectToAction("Details", new { movieId = model.Id });
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddToPlaylist(MovieDetailsViewModel model)
        {
            int playlistId = model.Playlist;
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_playlistService.GetPlaylistsByUserId(userId).Contains(_playlistService.Get(playlistId)))
            {
                _playlistService.AssignMovieToPlaylist(model.Id, playlistId);
            }
            return RedirectToAction("Details", new { movieId = model.Id });
        }


        public IActionResult RatingReview(int movieId) {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Movie movieFromDb = _movieService.Get(movieId);

            int eigenRating = userId != null && movieFromDb.RatingReviews.Count != 0 ?
                movieFromDb.RatingReviews.SingleOrDefault(r => r.MovieId == movieFromDb.Id && r.UserId == userId).Rating : -1;
            string eigenReview = userId != null && movieFromDb.RatingReviews.Count != 0 ?
                movieFromDb.RatingReviews.SingleOrDefault(r => r.MovieId == movieFromDb.Id && r.UserId == userId).Review : null;

            List<SelectListItem> ratingSelectList = new List<SelectListItem>();
            ratingSelectList.Add(new SelectListItem { Value = "-1", Text = "Geef rating" });
            for (var i = 0; i <= 10; i++)
            {
                ratingSelectList.Add(new SelectListItem { Value = i.ToString(), Text = i.ToString() });
            }

            MovieRatingReviewViewModel vm = new MovieRatingReviewViewModel
            {
                Id = movieFromDb.Id,
                Rating = eigenRating,
                Review = eigenReview,
                RatingSelectList = ratingSelectList,
                UserName = movieFromDb.RatingReviews.SingleOrDefault(u => u.UserId == userId).User.UserName
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult RatingReview(MovieRatingReviewViewModel model, int movieId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _RatingReviewService.AssignRatingReview(movieId, userId, model.Rating, model.Review);
            return RedirectToAction("Details", new { movieId = movieId });
        }


        [Authorize]
        public IActionResult Delete(int movieId)
        {
            Movie movieFromDb = _movieService.Get(movieId);
            MovieDeleteViewModel model = new MovieDeleteViewModel()
            {
                Naam = movieFromDb.Titel,
                Id = movieFromDb.Id
            };
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult ConfirmDelete(int movieId)
        {
            _movieService.Delete(movieId);
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Edit(int movieId) {
            Movie movieFromDb = _movieService.Get(movieId);
            List<MovieGenreListViewModel> genreList = new List<MovieGenreListViewModel>();
            List<int> genresInMovie = _genreService.GetGenresByMovieId(movieId).Select(g=>g.Id).ToList();
            foreach (var genre in _genreService.Get())
            {               
                genreList.Add(new MovieGenreListViewModel() { Naam = genre.Naam , Checked = genresInMovie.Contains(genre.Id)});
            };

            string regisseur = _regisseurService.GetRegisseursByMovieId(movieId).Select(r=>r.Naam).ToString();

            MovieEditViewModel vm = new MovieEditViewModel {
                Id = movieFromDb.Id,
                Beschrijving = movieFromDb.Beschrijving,
                GenreList = genreList,
                Regisseurs = regisseur,
                Speelduur = movieFromDb.Speelduur,
                Titel = movieFromDb.Titel
            };

            return View(vm);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(int movieId, MovieEditViewModel model) {
            Movie movieToEdit = new Movie
            {
                Beschrijving = model.Beschrijving,
                Titel = model.Titel,
                Speelduur = model.Speelduur
            };
            _movieService.Edit(movieId, movieToEdit);

            return RedirectToAction("Details", new { id = movieId });
        }
    }
}
