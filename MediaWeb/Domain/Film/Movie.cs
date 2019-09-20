using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain
{
    public class Movie
    {

        public int Id { get; set; }
        public int Speelduur { get; set; }
        public string Titel { get; set; }
        public ICollection<MovieGenre> Genres { get; set; }
        public ICollection<MovieRatingReview> RatingReviews { get; set; }
        public ICollection<MovieGezienStatus> GezienStatus { get; set; }



    }
}
