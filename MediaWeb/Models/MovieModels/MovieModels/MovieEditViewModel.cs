using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.MovieModels.MovieModels
{
    public class MovieEditViewModel
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public List<MovieGenreListViewModel> GenreList { get; set; }
        public string Regisseurs { get; set; }
        public IFormFile Foto { get; set; }
        public int Speelduur { get; set; }

        public string Beschrijving { get; set; }
        public string RegisseurList { get; set; }
    }
}
