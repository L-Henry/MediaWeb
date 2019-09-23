using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.PodcastDomain
{
    public class Podcast
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public int PodcastMakerId { get; set; }
        public PodcastMaker PodcastMaker { get; set; }

        public int Speelduur { get; set; }
        public DateTime Datum { get; set; }
        public ICollection<PodcastOnderwerpCombo> Onderwerpen { get; set; }
        public int PodcastSerieId { get; set; }
        public PodcastSerie PostcastSerie { get; set; }
        public bool Zichtbaar { get; set; } = true;

    }
}
