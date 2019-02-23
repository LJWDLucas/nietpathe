using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NietPathe.Models.Reviews
{
    public interface IReviewRepository
    {
        void DeleteReview(string id, string removalId);
        Task<Review> GetReviewById(string id);
        Task<List<Review>> GetUnapprovedReviews();
        Task<List<Review>> GetReviewsByMovieId(string movieId);
        void PostReview(Review review);
    }
}
