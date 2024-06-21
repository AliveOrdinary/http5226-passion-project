using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using PassionProjectN01664066.Models;

namespace PassionProjectN01664066.Controllers
{
    public class ReviewController : Controller
    {
        private static readonly HttpClient client;
        private JavaScriptSerializer jss = new JavaScriptSerializer();

        static ReviewController()
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                AllowAutoRedirect = false,
                UseCookies = false
            };

            client = new HttpClient(handler);
            client.BaseAddress = new Uri("https://localhost:44324/api/");
        }

        // GET: Review/List
        public ActionResult List()
        {
            string url = "reviewdata/listreviews";
            HttpResponseMessage response = client.GetAsync(url).Result;

            IEnumerable<Review> reviews = response.Content.ReadAsAsync<IEnumerable<Review>>().Result;

            return View(reviews);
        }

        // GET: Review/Details/5
        public ActionResult Details(int id)
        {
            string url = "reviewdata/findreview/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;

            Review review = response.Content.ReadAsAsync<Review>().Result;

            return View(review);
        }

        // Other action methods for Create, Edit, Delete
        // ...
    }
}