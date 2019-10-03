using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.SerieDomain
{
    public class SeriesEpisodesPlaylist
    {
    
        public int Id { get; set; }
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
        public string Titel { get; set; }

        public bool Publiek { get; set; } = true;
        public bool Zichtbaar { get; set; } = true;
    }
}
