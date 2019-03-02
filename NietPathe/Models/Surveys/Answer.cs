using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NietPathe.Models.Surveys
{
    public class Answer
    {
        [BsonElement("rating")]
        public int Rating { get; set; }

        [BsonElement("answer")]
        public string AnswerText { get; set; }
    }
}
