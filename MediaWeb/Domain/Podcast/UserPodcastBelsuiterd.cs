using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.Podcast
{
    public class UserPodcastBeluisterdStatus
    {
        public string UserId { get; set; }
        public int PodcastId { get; set; }
        public int PodcastBeluisterdStatusId { get; set; }
    }
}
