using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Domains
{
    public class Localizacoes
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonRequired]
        [BsonElement("titulo")]

        public string TituloLocal { get; set; }
        [BsonRequired]
        [BsonElement("latitude")]

        public string Latitude { get; set; }
        [BsonRequired]
        [BsonElement("longitude")]

        public string Longitude { get; set; }
    }
}