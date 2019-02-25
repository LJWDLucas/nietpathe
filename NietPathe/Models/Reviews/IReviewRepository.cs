using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace NietPathe.Models.Reviews
{
    public interface IReviewRepository
    {
        void DeleteReview(ObjectId reviewId, ObjectId removalId);
        void ApproveReview(ObjectId reviewId, string employeeId);
        Task<Review> GetReviewById(ObjectId id);
        Task<List<Review>> GetUnapprovedReviews();
        Task<List<Review>> GetReviewsByMovieId(string movieId);
        Review PostReview(Review review);
    }
}
