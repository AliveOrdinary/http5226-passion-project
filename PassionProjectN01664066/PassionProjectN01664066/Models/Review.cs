using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PassionProjectN01664066.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        [Required]
        public string UserId { get; set; }

        [Required]
        public int MovieId { get; set; }

        [Required]
        public int Rating {  get; set; }

        [Required]
        public string ReviewText { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Movie Movie { get; set; }
    }
}