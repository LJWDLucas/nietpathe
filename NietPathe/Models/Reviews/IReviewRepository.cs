using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace NietPathe.Models.Reviews
{
    public interface IReviewRepository
    {
        void DeleteReview(string reviewId, string removalId);
        void ApproveReview(string reviewId, string employeeId);
        Task<Review> GetReviewById(string id);
        Task<List<Review>> GetUnapprovedReviews();
        Task<List<Review>> GetReviewsByMovieId(string movieId);
        Review PostReview(Review review);
    }
}
