using MediaWeb.Domain.MovieDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Services.MovieServices
{
    public interface IMovieGezienStatusService
    {
        IEnumerable<MovieGezienStatus> Get();
        void AssignGezienStatus(int movieId, string userId, int gezienStatus);



    }
}
