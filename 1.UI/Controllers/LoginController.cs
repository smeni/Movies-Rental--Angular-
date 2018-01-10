using _1.UI.Coode;
using _2.BL;
using _4.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace _1.UI.Controllers
{
    public class LoginController : Controller
    {
        UserManager userManager;

        const string COOKIE_NAME = "username";
        SessionManager SessionManager;

        //c'tor with the initializ the BL managers.
        public LoginController()
        {
            userManager = new UserManager();
            SessionManager = new SessionManager();
        }

        //return to the Login view model.
        public ActionResult Index()
        {
            return View();
        }

        // 1) check the login details VS client details in DB.
        // 2) save the client details in session for relogin.
        [AllowAnonymous]
        public ActionResult Login(string Email, string Password, string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
              var users = userManager.Users.ToList();
            if (!(string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password)))
            {
                foreach (var item in users)
                {
                    if (item.Email == Email && item.Password == Password)
                    {
                        SessionManager.Email = Email;
                        FormsAuthentication.SetAuthCookie(Email, true);
                       
                        if (string.IsNullOrEmpty(returnUrl))
                        {
                            return RedirectToAction("Index","Movie");
                        }
                        else
                        {
                            return Redirect(returnUrl);
                        }
                    }
                }
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

 
        //do logout and delete client details from the session for his safty.
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Movie");
        }

        //return to the registration view model.
        public ActionResult Registration()
        {
            return View();
        }

        //do registration for new client and call BL function for create new User in DB.
        public ActionResult Create(Models.RegisterInfo registinfo)
        {
            //validate the user details
            if (registinfo.NickName != null && registinfo.Email !=null && registinfo.Password !=null)
            {
                Users newUser = new Users
                {
                    NickName = registinfo.NickName,
                    Email = registinfo.Email,
                    Password = registinfo.Password,
                    IsSctiv = true
                };
                userManager.Insert(newUser);
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View("Registration");
            }
        }
    }
}