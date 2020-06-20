using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainigDiaryMongo.Models
{
    public class Event : Entity
    {
        [BsonElement("EventName")]
        [DisplayName("Event name")]
        public string EventName { get; set; }
        [BsonElement("Location")]
        [DisplayName("Location")]
        public string Location { get; set; }
        [BsonElement("StartDate")]
        [DisplayName("Start date")]
        public DateTime StartDate { get; set; }
        [BsonElement("EndDate")]
        [DisplayName("End date")]
        public DateTime EndDate { get; set; }
        [BsonElement("Type")]
        [DisplayName("Type")]
        public string Type { get; set; }
        [BsonElement("Organiser")]
        [DisplayName("Organiser")]
        public Person Organiser { get; set; }
        [BsonElement("Participants")]
        [DisplayName("Participants")]
        public List<Person> Participants { get; set; } = new List<Person>();
        [BsonElement("Description")]
        [DisplayName("Description")]
        public string Description { get; set; }
        [NotMapped]
        public string CalendarColor { get; set; }
    }
}
