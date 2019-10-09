using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaWeb.Data;
using MediaWeb.Domain.MovieDomain;

namespace MediaWeb.Services.MovieServices
{
    public class MovieRatingReviewService : IMovieRatingReviewService
    {
        private readonly MediaContext _context;

        public MovieRatingReviewService(MediaContext context)
        {
            _context = context;
        }


        public void AssignRatingReview(int movieId, string userId, int eigenRating, string eigenReview = null)
        {
            if (_context.MovieRatingReview.Any(x => x.MovieId == movieId && x.UserId == userId))
            {
                _context.MovieRatingReview.SingleOrDefault(x => x.MovieId == movieId && x.UserId == userId).Rating = eigenRating;
                _context.MovieRatingReview.SingleOrDefault(x => x.MovieId == movieId && x.UserId == userId).Review = eigenReview;
            }
            else
            {
                _context.MovieRatingReview.Add(new MovieRatingReview { MovieId = movieId, UserId = userId, Rating = eigenRating, Review = eigenReview });
            }
            _context.SaveChanges();
        }

        public MovieRatingReview Get(int movieId, string userId)
        {
            return _context.MovieRatingReview.SingleOrDefault(x => x.MovieId == movieId && x.UserId == userId);
        }

        public int RatingByUserIdAndMovieId(string userId, int movieId) {
            return _context.MovieRatingReview.SingleOrDefault(rr => rr.UserId == userId && rr.MovieId == movieId).Rating;
        }

        public bool CheckIfReviewGeschrevenByUserIdForMovieId(string userId, int movieId) {
            return !String.IsNullOrEmpty(_context.MovieRatingReview.SingleOrDefault(rr => rr.UserId == userId && rr.MovieId == movieId).Review);
        }
    }
}
