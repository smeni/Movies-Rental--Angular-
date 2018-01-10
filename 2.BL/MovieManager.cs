using _3.DAL;
using _4.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BL
{
    public class MovieManager
    {
        private Movies_Rental_DBEntities ctx;

        public MovieManager()
        {
            ctx = new Movies_Rental_DBEntities();
        }

        public List<Movies> Movies
        {
            get
            {
                return ctx.Movies.Where(m => m.IsActiv == true).ToList();
            }
        }

        public Movies GetById(int movieId)
        {
            return ctx.Movies.Where(m => m.MovieID == movieId).FirstOrDefault();
        }
    }
}
