﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.SerieDomain
{
    public class UserSeriesEpisodesGezienStatus
    {
        public int SeriesEpisodeId { get; set; }
        public string UserId { get; set; }
        public int SerieGezienStatusId { get; set; }
    }
}
