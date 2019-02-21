using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using NietPathe.Models.Performances;

namespace NietPathe.Models
{
    public class Performance
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("threeDimensional")]
        public bool ThreeDimensional { get; set; }

        [BsonElement("movieId")]
        public string MovieId { get; set; }

        [BsonElement("startTime")]
        public string StartTime { get; set; }

        [BsonElement("endTime")]
        public string EndTime { get; set; }

        [BsonElement("hallId")]
        public string HallId { get; set; }

        [BsonElement("chairs")]
        public List<PerformanceChair> Chairs { get; set; }

    }
}
