using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.MovieModels.MovieRegisseurModels
{
    public class MovieRegisseurIndexViewModel
    {
        
        public string Naam { get; set; }
        public IEnumerable<MovieRegisseurListViewModel> ListVM { get; set; }
    }
}
