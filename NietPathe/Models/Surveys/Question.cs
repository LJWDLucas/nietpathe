using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NietPathe.Models.Surveys
{
    public class Question
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("question")]
        public string QuestionText { get; set; }

        [BsonElement("ratingRequired")]
        public bool RatingRequired { get; set; }

        [BsonElement("answerRequired")]
        public bool AnswerRequired { get; set; }

        public Question()
        {
            this.Id = ObjectId.GenerateNewId().ToString();
        }
    }
}
