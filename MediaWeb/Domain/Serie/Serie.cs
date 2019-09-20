using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.Serie
{
    public class Serie
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public string Beschrijving { get; set; }
        public ICollection<SeriesEpisodes> SeriesEpisodes { get; set; }
        public ICollection<SerieRatingReview> SerieRatingReview { get; set; }
        public byte[] Foto { get; set; }
        public ICollection<GenreSerieGenre> SerieGenres { get; set; }
        public bool Zichtbaar { get; set; } = true;
    }
}
