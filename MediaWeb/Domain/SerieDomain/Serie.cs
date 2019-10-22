using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.SerieDomain
{
    public class Serie
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public string Beschrijving { get; set; }
        public ICollection<SeriesEpisodesCombo> SeriesEpisodes { get; set; }
        public ICollection<SerieRatingReview> SerieRatingReview { get; set; }
        public byte[] Foto { get; set; }
        public ICollection<GenreSerieCombo> SerieGenres { get; set; }
        public bool Zichtbaar { get; set; } = true;
    }
}
