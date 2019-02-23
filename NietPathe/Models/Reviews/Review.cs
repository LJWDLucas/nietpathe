using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using NietPathe.Models.Performances;

namespace NietPathe.Models
{
    public class Review
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("approved")]
        public bool Approved { get; set; }

        [BsonElement("approvedBy")]
        public string ApprovedBy { get; set; }

        [BsonElement("movieId")]
        public string MovieId { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("removalId")]
        public string RemovalId { get; set; }

        [BsonElement("comment")]
        public string Comment { get; set; }

    }
}
