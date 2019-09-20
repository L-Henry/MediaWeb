using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.Movie
{
    public class Movie
    {

        public int Id { get; set; }
        public int Speelduur { get; set; }
        public string Titel { get; set; }
        public string Beschrijving { get; set; }
        public ICollection<GenreMovieGenre> Genres { get; set; }
        public ICollection<MovieRatingReview> RatingReviews { get; set; }
        public ICollection<UserMovieGezienStatus> UserMovieGezienStatus { get; set; }
        public byte[] Foto { get; set; }
        public ICollection<MovieRegisseurCombo> Regisseurs { get; set; }
        public ICollection<UserMoviePlaylist> UserMoviePlaylists { get; set; }

        public ICollection<UserMovieFav> UserMovieFav { get; set; }
        public bool Zichtbaar { get; set; } = true;

    }
}
