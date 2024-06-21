using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using PassionProjectN01664066.Models;

namespace PassionProjectN01664066.ApiControllers
{
    public class ReviewDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET api/reviewdata/listreviews
        [HttpGet]
        [ResponseType(typeof(Review))]
        public IHttpActionResult ListReviews()
        {
            List<Review> Reviews = db.Reviews.ToList();
            return Ok(Reviews);
        }

        // GET api/reviewdata/findreview/5
        [ResponseType(typeof(Review))]
        [HttpGet]
        public IHttpActionResult FindReview(int id)
        {
            Review Review = db.Reviews.Find(id);
            if (Review == null)
            {
                return NotFound();
            }

            return Ok(Review);
        }

        // Other action methods for POST, PUT, DELETE
        // ...
    }
}