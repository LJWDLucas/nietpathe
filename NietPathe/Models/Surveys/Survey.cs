using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NietPathe.Models.Surveys
{
    public class Survey
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("questions")]
        public List<Question> Questions { get; set; }

        [BsonElement("responses")]
        public Response Responses { get; set; }

        public Survey()
        {
            Id = ObjectId.GenerateNewId().ToString();
        }
    }
}
