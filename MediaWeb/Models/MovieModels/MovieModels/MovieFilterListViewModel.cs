using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.MovieModels.MovieModels
{
    public class MovieFilterListViewModel
    {

        public IEnumerable<MovieListViewModel> Movies { get; set; }
        public string Titel { get; set; }
        public int GezienStatus { get; set; }
        public List<SelectListItem> GezienStatusList { get; set; }
        public int Rating { get; set; }
        public List<SelectListItem> RatingList { get; set; }
        public int Genre { get; set; }
        public List<SelectListItem> GenreList { get; set; }

        public int Regisseur { get; set; }
        public List<SelectListItem> RegisseurList { get; set; }
    }
}
