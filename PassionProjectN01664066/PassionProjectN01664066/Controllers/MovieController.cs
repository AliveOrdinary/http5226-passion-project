using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Microsoft.AspNet.Identity;
using PassionProjectN01664066.Models;
using PassionProjectN01664066.Models.ViewModels;

namespace PassionProjectN01664066.Controllers
{
    public class MovieController : Controller
    {
        private static readonly HttpClient client;
        private JavaScriptSerializer jss = new JavaScriptSerializer();

        static MovieController()
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                AllowAutoRedirect = false,
                UseCookies = false
            };

            client = new HttpClient(handler);
            client.BaseAddress = new Uri("https://localhost:44352/api/");
        }

        private void GetApplicationCookie()
        {
            string token = "";
            client.DefaultRequestHeaders.Remove("Cookie");
            if (!User.Identity.IsAuthenticated) return;

            HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies.Get(".AspNet.ApplicationCookie");
            if (cookie != null) token = cookie.Value;

            Debug.WriteLine("Token Submitted is : " + token);
            if (token != "") client.DefaultRequestHeaders.Add("Cookie", ".AspNet.ApplicationCookie=" + token);

            return;
        }

        // GET: Movie/List
        public ActionResult List()
        {
            string url = "moviedata/listmovies";
            HttpResponseMessage response = client.GetAsync(url).Result;

            IEnumerable<Movie> movies = response.Content.ReadAsAsync<IEnumerable<Movie>>().Result;

            return View(movies);
        }

        // GET: Movie/Details/5
        public ActionResult Details(int id)
        {
            DetailsMovie ViewModel = new DetailsMovie();

            string url = "moviedata/findmovie/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;

            Movie SelectedMovie = response.Content.ReadAsAsync<Movie>().Result;
            ViewModel.SelectedMovie = SelectedMovie;

            return View(ViewModel);
        }

        [Authorize]
        public ActionResult AddMovie()
        {
            return View();
        }

        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult AddMovie(MovieViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();

                // First, add the movie to the Movies table
                var movie = new Movie
                {
                    Title = model.Title,
                    ReleaseYear = model.Year,
                    Director = model.Director,
                    Genre = model.Genre
                };
                db.Movies.Add(movie);
                db.SaveChanges();

                // Then, add the review
                var review = new Review
                {
                    UserId = userId,
                    MovieId = movie.MovieId,
                    //Rating = model.Rating,
                    ReviewText = model.Review
                };
                db.Reviews.Add(review);
                db.SaveChanges();

                return RedirectToAction("Dashboard", "Home");
            }

            return View(model);
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}