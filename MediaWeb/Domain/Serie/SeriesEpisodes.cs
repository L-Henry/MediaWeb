using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.Serie
{
    public class SeriesEpisodes
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public string Beschijving { get; set; }
        public bool Zichtbaar { get; set; }
        public ICollection<SerieGenre> SerieGenre { get; set; }

    }
}
