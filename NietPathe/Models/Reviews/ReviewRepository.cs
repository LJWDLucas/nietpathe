using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
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

        public void ApproveReview(ObjectId reviewId, string employeeId)
        {
            var filter = Builders<Review>.Filter.Eq(review => review.Id, reviewId);
            var update = Builders<Review>.Update.Set(review => review.EmployeeId, employeeId)
                    .Set(review => review.Approved, true);
            var result = _dataContext.Reviews.UpdateOneAsync(filter, update).Result;
        }

        public void DeleteReview(ObjectId reviewId, ObjectId removalId)
        {
            FilterDefinition<Review> filter = Builders<Review>.Filter.Eq(review => review.Id, reviewId) &
            Builders<Review>.Filter.Eq(review => review.RemovalId, removalId);
            _dataContext.Reviews.DeleteOne(filter);
        }

        public async Task<Review> GetReviewById(ObjectId id)
        {
            FilterDefinition<Review> filter = Builders<Review>.Filter.Eq(review => review.Id, id);
            return await _dataContext.Reviews.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<List<Review>> GetReviewsByMovieId(string movieId)
        {
            FilterDefinition<Review> filter = Builders<Review>.Filter.Eq(review => review.MovieId, movieId) &
                Builders<Review>.Filter.Eq(review => review.Approved, true);
            return await _dataContext.Reviews.Find(filter).ToListAsync();
        }

        public async Task<List<Review>> GetUnapprovedReviews()
        {
            FilterDefinition<Review> filter =
               Builders<Review>.Filter.Eq(review => review.Approved, false);
            return await _dataContext.Reviews.Find(filter).ToListAsync();
        }

        public Review PostReview(Review review)
        {
            _dataContext.Reviews.InsertOneAsync(review);
            return review;
        }
    }
}
