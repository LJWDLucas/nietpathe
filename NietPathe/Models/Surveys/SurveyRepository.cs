using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace NietPathe.Models.Surveys
{
    public class SurveyRepository : ISurveyRepository
    {
        private readonly IDataContext _dataContext;

        public SurveyRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }


        //public async Task<Survey> AddAnswerToSurvey(string id, List<Answer> answer)
        //{
        //    FilterDefinition<Survey> filter = Builders<Survey>.Filter.Eq(survey => survey.Id, id);
        //    var update = Builders<Survey>.Update.Push<List<Answer>>(e => e.Answers, answer);
        //    return await _dataContext.Surveys.FindOneAndUpdateAsync(filter, update);
        //}

        public async Task<Survey> AddQuestionToSurvey(string id, Question question)
        {
            FilterDefinition<Survey> filter = Builders<Survey>.Filter.Eq(survey => survey.Id, id);
            var update = Builders<Survey>.Update.Push<Question>(e => e.Questions, question);
            return await _dataContext.Surveys.FindOneAndUpdateAsync(filter, update);
        }

        public Survey CreateSurvey(Survey survey)
        {
            _dataContext.Surveys.InsertOneAsync(survey);
            return survey;
        }

        public void DeleteSurvey(string id)
        {
            FilterDefinition<Survey> filter = Builders<Survey>.Filter.Eq(survey => survey.Id, id);
            _dataContext.Surveys.DeleteOne(filter);
        }

        public async Task<Survey> GetSurveyById(string id)
        {
            FilterDefinition<Survey> filter = Builders<Survey>.Filter.Eq(survey => survey.Id, id);
            return await _dataContext.Surveys.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Survey>> GetSurveys()
        {
            var fields = Builders<Survey>.Projection.Include(s => s.Id).Include(s => s.Title);
            return await _dataContext.Surveys.Find(_ => true).Project<Survey>(fields).ToListAsync();
        }
       
        public bool UpdateSurvey(Survey survey)
        {
            FilterDefinition<Survey> filter = Builders<Survey>.Filter.Eq(m => m.Id, survey.Id);
            ReplaceOneResult replaceOneResult = _dataContext.Surveys.ReplaceOneAsync(filter, survey).Result;
            return replaceOneResult.IsAcknowledged && replaceOneResult.IsModifiedCountAvailable;
        }
    }
}
