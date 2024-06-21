using PassionProjectN01664066.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PassionProjectN01664066.ViewModels
{
    public class DashboardViewModel
    {
        public List<Review> WatchedMovies { get; set; }
        public List<Watchlist> Watchlist { get; set; }
    }
}