using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.MovieDomain
{
    public class MoviePlaylist
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
        public string Naam { get; set; }

        public bool Publiek { get; set; } = true;
        public bool Zichtbaar { get; set; } = true;

    }
}
