using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NietPathe.Models.Reviews;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NietPathe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : Controller
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewController(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        [HttpGet("unapproved")]
        public JsonResult GetUnapprovedReviews()
        {
            return Json(_reviewRepository.GetUnapprovedReviews().Result);
        }

        [HttpGet("{id}")]
        public JsonResult GetReview(string id)
        {
            return Json(_reviewRepository.GetReviewById(id).Result);
        }
        // post review
        // get unapproved reviews
        // get movie reviews
        // delete reviews

    }
}
