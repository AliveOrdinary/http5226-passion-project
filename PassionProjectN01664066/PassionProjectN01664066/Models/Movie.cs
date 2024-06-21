using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PassionProjectN01664066.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [Required]
        public string Title { get; set; }

        public int? ReleaseYear { get; set; }

        public string Director { get; set; }

        public string Genre { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Watchlist> Watchlist { get; set; }
    }
}