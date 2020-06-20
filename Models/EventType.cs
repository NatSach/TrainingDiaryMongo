using MongoDB.Bson.Serialization.Attributes;

namespace TrainigDiaryMongo.Models
{
    public class EventType : Entity
    {
        public EventType()
        {
        }

        public EventType(string name)
        {
            Name = name;
        }

        [BsonElement("Name")]
        public string Name { get; set; }
    }
}
