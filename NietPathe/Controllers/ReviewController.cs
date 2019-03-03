using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using NietPathe.Models;
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

        [HttpGet("{id}")]
        public JsonResult GetReview(string id)
        {
            return Json(_reviewRepository.GetReviewById(id).Result);
        }

        [HttpGet("unapproved")]
        public JsonResult GetUnapprovedReviews()
        {
            return Json(_reviewRepository.GetUnapprovedReviews().Result);
        }

        [HttpGet("{movieId}/reviews")]
        public JsonResult GetApprovedReviewsByMovieId(string movieId)
        {
            return Json(_reviewRepository.GetReviewsByMovieId(movieId).Result);
        }

        [HttpPost("approve/{reviewId}")]
        public JsonResult ApproveReview([FromRouteAttribute]string reviewId, [FromBody]Employee employee)
        {
            _reviewRepository.ApproveReview(reviewId, employee.EmployeeId);
            return new JsonResult
            (new { Data = "The approval request has been received." });
        }


        [HttpPost("post")]
        public JsonResult PostReview([FromBody]Review review)
        {
            return Json(_reviewRepository.PostReview(review));
        }

        /*
         * RemovalId is only available to backoffice employees. The original poster has these ids stored in their local storage.
         * This allows the (anonymous) original poster to delete their own posts, assuming their don't clear their storage.
         * If they do clear their storage, the review can only be deleted by employees.
         */

        [HttpDelete("{reviewId}/{removalId}")]
        public JsonResult DeleteReview([FromRouteAttribute]string reviewId, [FromRouteAttribute]string removalId)
        {
            _reviewRepository.DeleteReview(reviewId, removalId);
            return new JsonResult
            (new { Data = "The deletion request has been received." });
        }

        public class Employee
        {
            [BsonElement("employeeId")]
            public string EmployeeId { get; set; }
        }
    }
}
