using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using PassionProjectN01664066.Models;

namespace PassionProjectN01664066.Controllers
{
    public class WatchlistController : Controller
    {
        private static readonly HttpClient client;
        private JavaScriptSerializer jss = new JavaScriptSerializer();

        static WatchlistController()
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                AllowAutoRedirect = false,
                UseCookies = false
            };

            client = new HttpClient(handler);
            client.BaseAddress = new Uri("https://localhost:44324/api/");
        }

        // GET: Watchlist/List
        public ActionResult List()
        {
            string url = "watchlistdata/listwatchlists";
            HttpResponseMessage response = client.GetAsync(url).Result;

            IEnumerable<Watchlist> watchlists = response.Content.ReadAsAsync<IEnumerable<Watchlist>>().Result;

            return View(watchlists);
        }

        // GET: Watchlist/Details/5
        public ActionResult Details(int id)
        {
            string url = "watchlistdata/findwatchlist/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;

            Watchlist watchlist = response.Content.ReadAsAsync<Watchlist>().Result;

            return View(watchlist);
        }

        // Other action methods for Create, Edit, Delete
        // ...
    }
}