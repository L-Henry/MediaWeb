using MediaWeb.Domain.MovieDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Services.MovieServices
{
    public interface IMovieRatingReviewService
    {
        void AssignRatingReview(int movieId, string userId, int eigenRating, string eigenReview = null);
        MovieRatingReview Get(int movieId, string userId);

    }
}
