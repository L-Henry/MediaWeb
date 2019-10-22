using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.PodcastDomain
{
    public class UserPodcastFav
    {
        public int PodcastId { get; set; }
        public string UserId { get; set; }
    }
}
