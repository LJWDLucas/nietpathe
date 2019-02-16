using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace NietPathe.Models
{
    public class Movie
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("year")]
        public double Year { get; set; }

        [BsonElement("active")]
        public bool Active { get; set; }

        [BsonElement("runtime")]
        public string Runtime { get; set; }

        [BsonElement("genres")]
        public List<string> Genres { get; set; }

        [BsonElement("cast")]
        public List<string> Cast { get; set; }

        public Movie()
        {
        }
    }
}
