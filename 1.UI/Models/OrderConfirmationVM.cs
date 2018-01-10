using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1.UI.Models
{
    //COnfirm Order view model.
    public class OrderConfirmationVM
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public int MovieID { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
    }
}