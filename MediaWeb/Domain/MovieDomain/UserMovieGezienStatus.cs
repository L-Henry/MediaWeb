﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.MovieDomain
{
    public class UserMovieGezienStatus
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public string UserId { get; set; }
        public IdentityUser User { get; set; }

        public int MovieGezienStatusId { get; set; }
        public MovieGezienStatus MovieGezienStatus { get; set; }


    }
}
