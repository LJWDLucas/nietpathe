using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NietPathe.Models.Performances
{
    public class PerformanceChair
    {
        [BsonElement("ticketId")]
        public string TicketId { get; set; }

        [BsonElement("row")]
        public int Row { get; set; }

        [BsonElement("chair")]
        public int Chair { get; set; }

        [BsonElement("taken")]
        public bool Taken { get; set; }
    }
}
