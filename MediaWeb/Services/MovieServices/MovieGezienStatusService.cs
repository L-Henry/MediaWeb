using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaWeb.Data;
using MediaWeb.Domain.MovieDomain;

namespace MediaWeb.Services.MovieServices
{
    public class MovieGezienStatusService : IMovieGezienStatusService
    {
        private readonly MediaContext _context;

        public MovieGezienStatusService(MediaContext context)
        {
            _context = context;
        }


        public IEnumerable<MovieGezienStatus> Get()
        {
            return _context.MovieGezienStatus;
        }
    }
}
