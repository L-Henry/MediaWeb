using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.MovieDomain
{
    public class MoviePlaylistCombo
    {
        public int MovieId { get; set; }
        public int MoviePlaylistId { get; set; }
        public bool Publiek { get; set; } = true;
        public bool Zichtbaar { get; set; } = true;

    }
}
