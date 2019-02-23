using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace NietPathe.Models.Reviews
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly IDataContext _dataContext;

        public ReviewRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void DeleteReview(string id, string removalId)
        {
            throw new NotImplementedException();
        }

        public async Task<Review> GetReviewById(string id)
        {
            FilterDefinition<Review> filter = Builders<Review>.Filter.Eq(review => review.Id, id);
            return await _dataContext.Reviews.Find(filter).FirstOrDefaultAsync();
        }

        public Task<List<Review>> GetReviewsByMovieId(string movieId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Review>> GetUnapprovedReviews()
        {
            FilterDefinition<Review> filter =
               Builders<Review>.Filter.Eq(review => review.Approved, false);
            return await _dataContext.Reviews.Find(filter).ToListAsync();
        }

        public void PostReview(Review review)
        {
            throw new NotImplementedException();
        }
    }
}
