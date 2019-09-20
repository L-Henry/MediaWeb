using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.Podcast
{
    public class UserPodcastPlaylist
    {
        public int PodcastId { get; set; }
        public string UserId { get; set; }

        public int PodcastPlaylistId { get; set; }
        public bool Publiek { get; set; } = true;
        public bool Zichtbaar { get; set; } = true;

    }
}
