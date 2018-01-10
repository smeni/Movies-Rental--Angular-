using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _1.UI.Models
{
    //MyOrders view model.
    public class MyOrdersVM
    {
        public int OrderID { get; set; }

        public int UserID { get; set; }

        //from orders table
        [Display(Name ="תאריך הזמנה")]
        public System.DateTime StartDate { get; set; }

        //from movies table
        [Display(Name = "תמונה")]
        public string Picture { get; set; }

        [Display(Name = "שם הסרט")]
        public string MovieName { get; set; }

        //public int CategoryID { get; set; }

        //from categorys table
        [Display(Name = "קטגוריה")]
        public string CategoryName { get; set; }

        //frop prices table
        [Display(Name = "המחיר ששולם")]
        public decimal Price { get; set; }
    }
}