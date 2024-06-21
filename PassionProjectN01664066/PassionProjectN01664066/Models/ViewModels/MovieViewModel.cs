using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PassionProjectN01664066.Models.ViewModels
{
    public class MovieViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        [Range(1800, 2100)]
        public int Year { get; set; }

        public string Director { get; set; }

        public string Genre { get; set; }

        [Required]
        [Range(1, 10)]
        public decimal Rating { get; set; }

        [Required]
        public string Review { get; set; }
    }
}