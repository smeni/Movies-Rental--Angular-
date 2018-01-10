using _4.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1.UI.Models
{
    //Movies view model.
    public class MoviesVM
    {
        public int MovieID { get; set; }
        public string Picture { get; set; }
        public string MovieName { get; set; }
        public string CategoryName { get; set; }
        public string MovieTrailer { get; set; }
        public Double Level { get; set; }

    }
}
