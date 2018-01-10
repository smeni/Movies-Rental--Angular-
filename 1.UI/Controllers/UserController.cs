using _2.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1.UI.Controllers
{
    public class UserController : Controller
    {
        UserManager manager = new UserManager();

        //get the all users.
        // GET: User
        public ActionResult Index()
        {
            return View(manager.Users.ToList());
        }
    }
}