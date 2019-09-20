﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.Serie
{
    public class UserSeriesEpisodesPlaylist
    {
        public int SeriesEpisodeId { get; set; }
        public int SeriesEpisodesPlaylistId { get; set; }
        public string UserId { get; set; }
        public bool Publiek { get; set; } = true;
        public bool Zichtbaar { get; set; } = true;
    }
}