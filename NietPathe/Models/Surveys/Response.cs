using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace NietPathe.Models.Surveys
{
    public class Response
    {

        [BsonElement("questionId")]
        public string QuestionId { get; set; }

        [BsonElement("answers")]
        public List<Answer> Answers { get; set; }
    }
}
