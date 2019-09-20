using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.Podcast
{
    public class PodcastSerie
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public ICollection<Podcast> Podcasts { get; set; }
        public bool Zictbaar { get; set; }

    }
}
