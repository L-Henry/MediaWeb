using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.Podcast
{
    public class Podcast
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public int PodcastMakerId { get; set; }
        public PodcastMaker PodcastMaker { get; set; }

        public int Speelduur { get; set; }
        public DateTime Datum { get; set; }
        public ICollection<PodcastOnderwerpen> Onderwerpen { get; set; }

        public bool Zichtbaar { get; set; } = true;

    }
}
