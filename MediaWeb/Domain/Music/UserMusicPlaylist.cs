using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.Music
{
    public class UserMusicPlaylist
    {

        public int MusicId { get; set; }
        public string UserId { get; set; }
        public int MusicPlaylistId { get; set; }
        public bool Publiek { get; set; } = true;
        public bool Zichtbaar { get; set; } = true;

    }
}
