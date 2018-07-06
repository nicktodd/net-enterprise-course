using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NetCoreWeb.Repository
{
    public class CompactDisc
    {
        public ObjectId Id { get; set; }

        [BsonElement("CdId")]
        public int CdId { get; set; }

        [BsonElement("Title")]
        public string Title { get; set; }

        [BsonElement("Artist")]
        public string Artist{ get; set; }


        [BsonElement("Price")]
        public decimal Price { get; set; }

    }
}
