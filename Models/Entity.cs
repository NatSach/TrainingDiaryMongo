using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace TrainigDiaryMongo.Models
{
    public abstract class Entity
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }

    }
}
