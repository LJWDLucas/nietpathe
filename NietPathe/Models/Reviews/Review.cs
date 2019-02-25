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
        public ObjectId Id { get; set; }

        [BsonElement("approved")]
        public bool Approved { get; set; }

        [BsonElement("employeeId")]
        public string EmployeeId { get; set; }

        [BsonElement("movieId")]
        public string MovieId { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("removalId")]
        public ObjectId RemovalId { get; set; }

        [BsonElement("comment")]
        private string comment;

        [BsonIgnore]
        public string Comment
        { 
            get
            {
                return this.comment;
            }
            set
            { 
                if (value.Length > 4500)
                {
                    comment = value.Substring(0, 4499);
                }
                else
                {
                    comment = value;
                }
            } 
        }

        public Review()
        {
            this.Id = ObjectId.GenerateNewId();
            this.RemovalId = ObjectId.GenerateNewId();
            this.Approved = false;
        }

    }
}
