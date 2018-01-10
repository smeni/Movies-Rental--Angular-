using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1.UI.Models
{
    
    public class OrderDetailsVM
    {
        //from orders table
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public System.DateTime StartDate { get; set; }

        //from movies table
        public int MovieID { get; set; }
        public string MovieName { get; set; }
        public string CategoryName { get; set; }
        public string Picture { get; set; }
        public string MovieTrailer { get; set; }

        //from prices table
        public decimal Price { get; set; }
    }
}