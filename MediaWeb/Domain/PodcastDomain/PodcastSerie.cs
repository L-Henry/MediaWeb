﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.PodcastDomain
{
    public class PodcastSerie
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public ICollection<PodcastSerieCombo> Podcasts { get; set; }
        public bool Zichtbaar { get; set; } = true;

    }
}
