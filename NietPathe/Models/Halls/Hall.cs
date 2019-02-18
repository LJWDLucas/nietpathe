using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using NietPathe.Models.Halls;

namespace NietPathe.Models
{
    public class Hall
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("rows")]
        public int Rows { get; set; }

        [BsonElement("chairs")]
        public List<RowChairs> Chairs {get; set;}

        [BsonElement("legroom")]
        public int Legroom { get; set; }

        [BsonElement("3d")]
        public bool ThreeD { get; set; }

        [BsonElement("dolbysurround")]
        public bool DolbySurround { get; set; }

        [BsonElement("skyview")]
        public bool SkyView { get; set; }

        [BsonElement("wheelchairaccessible")]
        public bool WheelchairAccessible { get; set; }

    }
}
