using Microsoft.AspNet.Identity;
using PassionProjectN01664066.Models;
using PassionProjectN01664066.Services;
using PassionProjectN01664066.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PassionProjectN01664066.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private OmdbService _omdbService = new OmdbService();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        [Authorize]
        public ActionResult Dashboard()
        {
            var userId = User.Identity.GetUserId();
            var watchedMovies = db.Reviews.Where(r => r.UserId == userId).Include(r => r.Movie).ToList();
            var watchlist = db.Watchlist.Where(w => w.UserId == userId).Include(w => w.Movie).ToList();

            var viewModel = new DashboardViewModel
            {
                WatchedMovies = watchedMovies,
                Watchlist = watchlist
            };

            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> SearchMovies(string searchTerm)
        {
            var searchResults = await _omdbService.SearchMovies(searchTerm);

            System.Diagnostics.Debug.WriteLine($"OMDB API Response: {searchResults}");

            // Return the raw JSON string
            return Content(searchResults, "application/json");
        }
    }
}