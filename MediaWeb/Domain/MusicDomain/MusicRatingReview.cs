﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.MusicDomain
{
    public class MusicRatingReview
    {
        public int MusicId { get; set; }
        public string UserId { get; set; }

        public int Rating { get; set; }
        public string Review { get; set; }
        
        public bool Zichtbaar { get; set; } = true;
    }
}
