using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.SerieDomain
{
    public class SeriesEpisodeRatingReview
    {
        public int SeriesEpisodesId { get; set; }
        public string UserId { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }
        public bool Zichtbaar { get; set; } = true;

    }
}
