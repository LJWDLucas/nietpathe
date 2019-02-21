using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NietPathe.Models.Halls
{
    public class RowChairs
    {
        [BsonElement("ticketId")]
        public string TicketId { get; set; }

        [BsonElement("row")]
        public int Row { get; set; }

        [BsonElement("chairs")]
        public int Chairs { get; set; }
    }
}
