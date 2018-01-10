using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace _1.UI.Coode
{
    //this class manage the session for the reentering.
    public class SessionManager
    {
        const string EMAIL = "Email";

        private static HttpSessionState Session
        {
            get
            {
                return HttpContext.Current.Session;
            }
        }


        public static string Email
        {
            get
            {
                if (Session[EMAIL] == null)
                    Session[EMAIL] = 0;
                return (string)Session[EMAIL];
                //return (int)Session[EMAIL];
            }
            set
            {
                Session[EMAIL] = value;
            }
        }
    }
}