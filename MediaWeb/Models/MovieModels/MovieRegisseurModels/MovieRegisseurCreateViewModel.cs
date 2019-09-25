using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.MovieModels.MovieRegisseurModels
{
    public class MovieRegisseurCreateViewModel
    {
        [Required(ErrorMessage = "Naam is nodig")]
        [MinLength(5)]
        public string Naam { get; set; }
    }
}
