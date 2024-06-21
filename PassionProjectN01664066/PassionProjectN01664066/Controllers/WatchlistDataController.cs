using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using PassionProjectN01664066.Models;

namespace PassionProjectN01664066.ApiControllers
{
    public class WatchlistDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET api/watchlistdata/listwatchlists
        [HttpGet]
        [ResponseType(typeof(Watchlist))]
        public IHttpActionResult ListWatchlists()
        {
            List<Watchlist> Watchlists = db.Watchlist.ToList();
            return Ok(Watchlists);
        }

        // GET api/watchlistdata/findwatchlist/5
        [ResponseType(typeof(Watchlist))]
        [HttpGet]
        public IHttpActionResult FindWatchlist(int id)
        {
            Watchlist Watchlist = db.Watchlist.Find(id);
            if (Watchlist == null)
            {
                return NotFound();
            }

            return Ok(Watchlist);
        }

        // Other action methods for POST, PUT, DELETE
        // ...
    }
}