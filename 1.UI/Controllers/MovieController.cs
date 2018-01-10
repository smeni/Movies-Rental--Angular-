using _1.UI.Coode;
using _1.UI.Models;
using _2.BL;
using _3.DAL;
using _4.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1.UI.Controllers
{
    public class MovieController : Controller
    {
        OrderManager omanager;
        MovieManager manager;
        UserManager umanager;

        //c'tor with the initializ the BL managers.
        public MovieController()
        {
            omanager = new OrderManager();
            manager = new MovieManager();
            umanager = new UserManager();

        }

        // GET: Movie
        //Get all movies for home page.
        public ActionResult Index()
        {
            List<MoviesVM> listVM = new List<MoviesVM>();
            var allMoviess = ConvertMoviesToVM(manager.Movies.ToList());
            return View(allMoviess);
        }

        [Authorize] //view the specific selected movie.
        public ActionResult ClientChoice(int movieID)
        {
            var selectedMovie = manager.GetById(movieID);
            Orders newOrder = new Orders();

            OrderDetailsVM vm = new OrderDetailsVM
            {
                OrderID = newOrder.OrderID,
                UserID = newOrder.UserID,
                StartDate = DateTime.Now,

                MovieID = selectedMovie.MovieID,
                Picture = selectedMovie.Picture,
                MovieName = selectedMovie.MovieName,
                CategoryName = selectedMovie.Categorys.CategoryName,
                MovieTrailer = selectedMovie.MovieTrailer,

                Price = selectedMovie.Prices.Price
            };
            return View(vm);
        }

        //Do work for Ajax script - sort movie by category and return to view by Ajax.
        public ActionResult GetCarsByFilter(string category)
        {
            List<MoviesVM> MoviesByCategory = new List<MoviesVM>();
            var allMoviess = ConvertMoviesToVM(manager.Movies.ToList());

            if (category.Contains(""))
            {
                return PartialView(allMoviess);
            }
            else
            {
                foreach (var item in allMoviess)
                {
                    if (item.CategoryName == category)
                    {
                        MoviesByCategory.Add(item);
                    }
                }
                return PartialView(MoviesByCategory);
            }
        }

        //converting function from entitiy model to the view model objects.
        private List<MoviesVM> ConvertMoviesToVM(List<Movies> movies)
        {
            List<MoviesVM> moviesVm = new List<MoviesVM>();
            foreach (var item in movies)
            {
                MoviesVM vm = new MoviesVM
                {
                    MovieID = item.MovieID,
                    Picture = item.Picture,
                    MovieName = item.MovieName,
                    CategoryName = item.Categorys.CategoryName,
                    MovieTrailer = item.MovieTrailer,
                    Level = (Double)item.Prices.Price,
                };
                moviesVm.Add(vm);
            }
            return moviesVm;
        }

        //get the client choice and create new Order in DB.
        public ActionResult CreateNewOrder(int movieId, DateTime startDate)
        {
            var userMail = (string)Session["Email"];
            var user = umanager.Users.Where(u => u.Email == userMail).FirstOrDefault();

            Orders newOrder = new Orders()
            {
                UserID = user.UserID,
                MovieID = movieId,
                StartDate = startDate,
                EndDate = startDate.AddDays(1),
                IsActiv = true
            };
            omanager.Insert(newOrder);
            return PartialView();
        }

       

        //Get All Movies to the main page useing in Angular
        public JsonResult MoviesByAngular()
        {
            List<MoviesVM> listVM = new List<MoviesVM>();
            var allMoviess = ConvertMoviesToVM(manager.Movies.ToList());
            return Json(allMoviess, JsonRequestBehavior.AllowGet);
        }
    }
}


