using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.MovieModels.MovieModels
{
    public class MovieDetailsViewModel
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public byte?[] FotoFile { get; set; }
        public string Genres { get; set; }
        public string Regisseurs { get; set; }
        public int Rating { get; set; }
        public List<MovieRatingReviewViewModel> RatingReview { get; set; }
        public int AantalGezien { get; set; }
        public int HeeftGezien { get; set; }
        public List<SelectListItem> HeeftGezienSelectList { get; set; }
        public int AantalWilZien { get; set; }
        public int EigenRating { get; set; }
        public List<SelectListItem> EigenRatingSelectList { get; set; }



        //public string Foto
        //{
        //    get
        //    {
        //        string mimeType = "png";
        //        string base64 = Convert.ToBase64String(FotoFile);
        //        return string.Format("data:{0};base64,{1}", mimeType, base64);
        //    }
        //}

    }
}
