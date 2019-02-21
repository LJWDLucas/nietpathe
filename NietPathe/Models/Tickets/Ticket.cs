using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace NietPathe.Models
{
    public class Ticket
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        [BsonElement("performanceId")]
        public string PerformanceId { get; set; }

        [BsonElement("chair")]
        public int Chair { get; set; }

        [BsonElement("row")]
        public int Row { get; set; }

        [BsonElement("price")]
        public double Price { get; set; }

        [BsonElement("discount")]
        public int Discount { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        public Ticket()
        {
            this.Id = ObjectId.GenerateNewId();
        }
    }
}
