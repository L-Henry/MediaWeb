using MediaWeb.Domain.MovieDomain;
using MediaWeb.Models.MyMediaModels;
using MediaWeb.Services.MovieServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MediaWeb.Controllers.MyMediaControllers
{
    public class MyMediaController : Controller
    {
        private readonly IMyMovieService _myMovieService;
        private readonly IMyMoviePlaylistService _myMoviePlaylistService;
        private readonly IMovieGenreService _movieGenreService;
        private readonly IMoviePlaylistService _moviePlaylistService;
        private readonly IMovieRatingReviewService _movieRatingReviewService;

        public MyMediaController(IMyMoviePlaylistService myMoviePlaylistService, IMyMovieService myMovieService, IMovieGenreService movieGenreService, 
                                 IMoviePlaylistService moviePlaylistService, IMovieRatingReviewService movieRatingReviewService)
        {
            _myMoviePlaylistService = myMoviePlaylistService;
            _myMovieService = myMovieService;
            _movieGenreService = movieGenreService;
            _moviePlaylistService = moviePlaylistService;
            _movieRatingReviewService = movieRatingReviewService;
        }

        [Authorize]
        public IActionResult Index() {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            IEnumerable<Movie> myMovies = _myMovieService.GetByUserId(userId);
            IEnumerable<MoviePlaylist> myPlaylists = _myMoviePlaylistService.GetByUserId(userId);

            List<MyMediaMoviesViewModel> movieVMs = new List<MyMediaMoviesViewModel>();
            foreach (var movie in myMovies)
            {
                string genres = _movieGenreService.GetGenresByMovieId(movie.Id) != null ? string.Join(",", _movieGenreService.GetGenresByMovieId(movie.Id).Select(x => x.Naam)) : "Geen genres";

                int ratingAvg = movie.RatingReviews != null && movie.RatingReviews.Where(r => r.MovieId == movie.Id).Select(r => r.Rating).Count() != 0 ?
                   movie.RatingReviews.Where(rat => rat.MovieId == movie.Id && rat.Rating > -1).Select(r => r.Rating).Sum()
                   / movie.RatingReviews.Where(rat => rat.MovieId == movie.Id && rat.Rating > -1).Count() : -1;

                int aantalGezien = movie.UserMovieGezienStatus != null ?
                        movie.UserMovieGezienStatus.Where(s => s.MovieId == movie.Id && s.MovieGezienStatus != null && s.MovieGezienStatusId == 2).Count() : 0;

                movieVMs.Add(new MyMediaMoviesViewModel
                {
                    Id = movie.Id,
                    Titel = movie.Titel,
                    AantalGezien = aantalGezien,
                    Rating = ratingAvg,
                    Genres = genres,
                    MyRating = _movieRatingReviewService.RatingByUserIdAndMovieId(userId, movie.Id),
                    ReviewGeschreven = _movieRatingReviewService.CheckIfReviewGeschrevenByUserIdForMovieId(userId, movie.Id)
                });
            }

            List<MyMediaMoviePlaylistsViewModel> playlistVMs = new List<MyMediaMoviePlaylistsViewModel>();
            foreach (var pl in myPlaylists)
            {
                playlistVMs.Add(new MyMediaMoviePlaylistsViewModel
                {
                    Id = pl.Id,
                    Naam = pl.Naam,
                    Speelduur = _moviePlaylistService.TotaleSpeelduur(pl.Id),
                    Aantal = _moviePlaylistService.AantalMoviesInPlaylist(pl.Id),
                    Publiek = pl.Publiek
                });
            }


            MyMediaViewModel vm = new MyMediaViewModel {
                MyMovies = movieVMs,
                MyPlaylists = playlistVMs
            };

            return View(vm);
        }



    }
}
