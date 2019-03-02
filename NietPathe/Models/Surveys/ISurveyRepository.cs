using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NietPathe.Models.Surveys
{
    public interface ISurveyRepository
    {
        Task<IEnumerable<Survey>> GetSurveys();
        Task<Survey> GetSurveyById(string id);
        void DeleteSurvey(string id);
        Survey CreateSurvey(Survey survey);
        bool UpdateSurvey(Survey survey);
        Task<Survey> AddQuestionToSurvey(string id, Question question);
        //Task<Survey> AddAnswerToSurvey(string id, List<Answer> answer);
    }
}
