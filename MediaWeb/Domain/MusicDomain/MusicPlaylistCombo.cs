using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.MusicDomain
{
    public class MusicPlaylistCombo
    {

        public int MusicId { get; set; }
        public int MusicPlaylistId { get; set; }
        public bool Publiek { get; set; } = true;
        public bool Zichtbaar { get; set; } = true;

    }
}
