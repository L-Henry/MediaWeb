using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.PodcastDomain
{
    public class PodcastRatingReview
    {
        public int PodcastId { get; set; }
        public string UserId { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }

        public bool Zichtbaar { get; set; } = true;
    }
}
