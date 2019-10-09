using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaWeb.Data;
using MediaWeb.Domain.MovieDomain;

namespace MediaWeb.Services.MovieServices
{
    public class MyMovieService : IMyMovieService
    {
        private readonly MediaContext _context;
        public MyMovieService(MediaContext context)
        {
            _context = context;
        }


        public IEnumerable<Movie> GetByUserId(string userId)
        {
            var movieIds = _context.UserMovieGezienStatus.Where(s => s.UserId == userId && s.MovieGezienStatusId == 2).Select(m=>m.MovieId).ToList();
            var result = _context.Movies.Where(m => movieIds.Contains(m.Id));
            return result;
        }
    }
}
