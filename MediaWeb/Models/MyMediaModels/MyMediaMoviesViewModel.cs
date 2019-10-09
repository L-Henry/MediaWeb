using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.MyMediaModels
{
    public class MyMediaMoviesViewModel
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public string Genres { get; set; }
        public int Rating { get; set; }
        public int AantalGezien { get; set; }
        public int MyRating { get; set; }
        public bool ReviewGeschreven { get; set; }
    }
}
