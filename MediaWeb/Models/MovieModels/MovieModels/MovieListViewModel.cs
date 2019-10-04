using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.MovieModels.MovieModels
{
    public class MovieListViewModel
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public string Beschrijving { get; set; }
        public string Regisseurs { get; set; }
        public string Genres { get; set; }
        public int Rating { get; set; }
        public int AantalGezien { get; set; }
        public List<SelectListItem> HeeftGezienSelectList { get; set; }
        public int HeeftGezien { get; set; }


    }
}
