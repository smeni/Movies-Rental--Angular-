using _1.UI.Models;
using _2.BL;
using _4.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1.UI.Controllers
{
    public class OrderController : Controller
    {
        OrderManager manager;
        MovieManager mManager;
        UserManager umanager;

        //c'tor with the initializ the BL managers.
        public OrderController()
        {
            manager = new OrderManager();
            mManager = new MovieManager();
            umanager = new UserManager();
        }

        //Get all Orders.
        //GET: Order
        public ActionResult Index()
        {
            return View(manager.Orders.ToList());
        }


        [Authorize] //view the specific client orders.
        public ActionResult AllOrders()
        {
            var userMail = (string)Session["Email"];
            var user = umanager.Users.Where(u => u.Email == userMail).FirstOrDefault();
            var orders = manager.Orders;
            List<MyOrdersVM> myOrders = new List<MyOrdersVM>();

            foreach (var item in orders)
            {
                if (item.UserID == user.UserID)
                {
                    MyOrdersVM myOrder = new MyOrdersVM
                    {
                        UserID = item.UserID,
                        OrderID = item.OrderID,
                        StartDate = item.StartDate,
                        Picture = item.Movies.Picture,
                        MovieName = item.Movies.MovieName,
                        CategoryName = item.Movies.Categorys.CategoryName,
                        Price = item.Movies.Prices.Price
                    };
                    myOrders.Add(myOrder);
                };
            }
            return View(myOrders);
        }

        public ActionResult Delete(int id ,int userId)
        {
            var orderToDelete = manager.GetById(id,userId);
            if (manager.Delete(orderToDelete))
            {
                return RedirectToAction("AllOrders");
            }
            else
            {
                return View("Error");
            }
        }
    }
}