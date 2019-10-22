using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.MovieModels.MovieGenreModels
{
    public class MovieGenreCreateViewModel
    {
        [Required(ErrorMessage = "Naam is nodig")]
        [MinLength(3)]
        public string Naam { get; set; }

    }
}
