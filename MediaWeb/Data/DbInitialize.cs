using MediaWeb.Domain.MovieDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Data
{
    public class DbInitialize
    {

        public static void Initialize(MediaContext context)
        {
            context.Database.EnsureCreated();

            if (context.MovieGezienStatus.Any())
            {
                ;
            }
            else
            {
                var status = new MovieGezienStatus[]
                {
                    new MovieGezienStatus{ Status = "Ongekend"},
                    new MovieGezienStatus{ Status = "Gezien"},
                    new MovieGezienStatus{ Status = "Wil zien" }
                };
                foreach (var item in status)
                {
                    context.MovieGezienStatus.Add(item);
                }
            }

            context.SaveChanges();

            if (context.Movies.Any())
            {
                ;
            }
            else
            {
                for (int i = 0; i < 20; i++)
                {
                    context.Movies.Add(new Movie { Titel = "Titel" + i, Speelduur = i * 10, Foto = null });
                }
            }

            context.SaveChanges();


        }
    }
}
