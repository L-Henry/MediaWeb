﻿using MediaWeb.Domain.MovieDomain;
using MediaWeb.Models.MovieModels.MovieModels;
using MediaWeb.Models.MovieModels.MoviePlaylistModels;
using MediaWeb.Services.MovieServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MediaWeb.Controllers.MovieControllers
{
    public class MoviePlaylistController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IMovieRegisseurService _regisseurService;
        private readonly IMovieGenreService _genreService;
        private readonly IMovieGezienStatusService _GezienStatusService;
        private readonly IMovieRatingReviewService _RatingReviewService;
        private readonly IMoviePlaylistService _playlistService;



        public MoviePlaylistController(IMovieService movieService, IMovieRegisseurService regisseurService, IMovieGenreService genreService,
            IMovieGezienStatusService gezienStatusService, IMovieRatingReviewService ratingReviewService, IMoviePlaylistService playlistService)
        {
            _movieService = movieService;
            _regisseurService = regisseurService;
            _genreService = genreService;
            _GezienStatusService = gezienStatusService;
            _RatingReviewService = ratingReviewService;
            _playlistService = playlistService;
        }


        public IActionResult Index() {
            IEnumerable<MoviePlaylist> playlistsFromDb = _playlistService.Get();
            List<MoviePlaylistViewModel> vm = new List<MoviePlaylistViewModel>();

            foreach (var pl in playlistsFromDb)
            {
                vm.Add(new MoviePlaylistViewModel { Naam = pl.Naam, Aantal = _playlistService.AantalMoviesInPlaylist(pl.Id), Id = pl.Id, Speelduur = _playlistService.TotaleSpeelduur(pl.Id) });
            }

            return View(vm);
        }

        [Authorize]
        public IActionResult Create() {
            MoviePlaylistCreateViewModel vm = new MoviePlaylistCreateViewModel();
            return View(vm);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(MoviePlaylistCreateViewModel model) {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            MoviePlaylist playlist = new MoviePlaylist {
                Naam = model.Naam,
                UserId = userId ?? null,
                Zichtbaar = true,
                Publiek = model.Publiek == "Publiek"
            };

            _playlistService.Insert(playlist);
            return RedirectToAction("Details", new { playlistId = playlist.Id });
        }


        public IActionResult Details(int playlistId) {
            MoviePlaylist playlistFromDb = _playlistService.Get(playlistId);
            IEnumerable<Movie> moviesFromDb = _movieService.GetMoviesByPlaylistId(playlistId);
            List<MoviePlaylistMoviesListViewModel> moviesList = new List<MoviePlaylistMoviesListViewModel>();
            foreach (var mov in moviesFromDb)
            {
                int ratingAvg = mov.RatingReviews != null && mov.RatingReviews.Where(r => r.MovieId == mov.Id).Select(r => r.Rating).Count() != 0 ?
                   mov.RatingReviews.Where(rat => rat.MovieId == mov.Id && rat.Rating > -1).Select(r => r.Rating).Sum()
                   / mov.RatingReviews.Where(rat => rat.MovieId == mov.Id && rat.Rating > -1).Count() : -1;

                int aantalGezien = mov.UserMovieGezienStatus != null ?
                        mov.UserMovieGezienStatus.Where(s => s.MovieId == mov.Id && s.MovieGezienStatus != null && s.MovieGezienStatusId == 2).Count() : 0;

                moviesList.Add(new MoviePlaylistMoviesListViewModel
                {
                    Id = mov.Id,
                    Speelduur = mov.Speelduur,
                    Titel = mov.Titel,
                    Rating = ratingAvg,
                    AantalGezien = aantalGezien
                });
            }

            MoviePlaylistDetailsListView vm = new MoviePlaylistDetailsListView {
                Movies = moviesList,
                Naam = playlistFromDb.Naam,
                Aantal = _playlistService.AantalMoviesInPlaylist(playlistId),
                Id = playlistFromDb.Id,
                Speelduur = _playlistService.TotaleSpeelduur(playlistId),
                Username = playlistFromDb.User.UserName
            };

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            vm.IsCurrentUserOwnerOfPlaylist = userId == playlistFromDb.UserId;

            return View(vm);
        }
        [Authorize]
        public IActionResult Edit(int playlistId) {
            MoviePlaylist moviePlaylistFromDb = _playlistService.Get(playlistId);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            MoviePlaylistEditViewModel vm = new MoviePlaylistEditViewModel {
                Id = moviePlaylistFromDb.Id,
                Naam = moviePlaylistFromDb.Naam,
                Publiek = moviePlaylistFromDb.Publiek ? "Publiek" : "Privé",
                IsCurrentUserOwnerOfPlaylist = moviePlaylistFromDb.UserId == userId
            };
            return View(vm);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(MoviePlaylistEditViewModel model) {
            MoviePlaylist playlistToEdit = new MoviePlaylist
            {
                Naam = model.Naam,
                Publiek = model.Publiek == "Publiek"
            };
            _playlistService.Edit(model.Id, playlistToEdit);
            return RedirectToAction("Details", new { playlistId = model.Id});
        }



        [Authorize]
        public IActionResult Delete(int playlistId)
        {
            MoviePlaylist playlist = _playlistService.Get(playlistId);
            MoviePlaylistDeleteViewModel vm = new MoviePlaylistDeleteViewModel
            {
                Id = playlist.Id,
                Naam = playlist.Naam
            };
            return View(vm);
        }

        [Authorize]
        [HttpPost]
        public IActionResult ConfirmDelete(int playlistId)
        {
            _playlistService.Delete(playlistId);
            return RedirectToAction("Index", "MyMedia");
        }

    }
}
