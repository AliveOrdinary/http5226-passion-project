using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PassionProjectN01664066.Models
{
    public class Watchlist
    {
        [Key]
        public int WatchlistId { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public int MovieId { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Movie Movie { get; set; }
    }
}