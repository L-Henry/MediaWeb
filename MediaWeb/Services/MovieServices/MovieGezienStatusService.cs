using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaWeb.Data;
using MediaWeb.Domain.MovieDomain;
using Microsoft.EntityFrameworkCore;

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

        public void AssignGezienStatus(int movieId, string userId, int gezienStatus)
        {
            if (_context.UserMovieGezienStatus.Count() != 0 && _context.UserMovieGezienStatus.Any(x => x.MovieId == movieId && x.UserId == userId))
            {
                _context.UserMovieGezienStatus.SingleOrDefault(x => x.MovieId == movieId && x.UserId == userId).MovieGezienStatus =
                _context.MovieGezienStatus.SingleOrDefault(s => s.Id == gezienStatus);
            }
            else
            {
                _context.UserMovieGezienStatus.Add(new UserMovieGezienStatus { MovieId = movieId, UserId = userId, MovieGezienStatus = _context.MovieGezienStatus.SingleOrDefault(s => s.Id == gezienStatus) });
            }
            _context.SaveChanges();
        }
    }
}
