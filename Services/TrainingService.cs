using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using TrainigDiaryMongo.Models;

namespace TrainigDiaryMongo.Services
{
    public class TrainingService
    {
        private readonly IMongoCollection<Event> _events;
        private readonly IMongoCollection<EventType> _eventTypes;

        public TrainingService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _events = database.GetCollection<Event>(settings.TrainingCollectionName);
            _eventTypes = database.GetCollection<EventType>(settings.EventTypeCollectionName);
        }

        public void CreateEventType(EventType eventType)
        {
            _eventTypes.InsertOne(eventType);
        }

        public List<EventType> GetEventTypes()
        {
            return _eventTypes.Find(eventType => true).ToList();
        }

        public List<Event> GetEvents()
        {
            return _events.Find(sportEvent => true).ToList();
        }

        public List<Event> GetEvents(string name, string types, DateTime? startDate, DateTime? endDate)
        {
            var result = _events.Aggregate();


            if(!string.IsNullOrWhiteSpace(name))
            {
                result = result.Match(sportEvent => sportEvent.EventName.ToLower().Contains(name.ToLower()));
            }

            if(!string.IsNullOrWhiteSpace(types))
            {
                var typeArray = types.Split(',');

           //     filters.Add(Builders<Message>.Filter.In("Domain", List<int>(){ a1,a2}));
//
                var filter = Builders<Event>.Filter.In(nameof(Event.Type), typeArray);
                result = result.Match(filter);
            }

            if(startDate != null)
            {
                result = result.Match(sportEvent => sportEvent.StartDate >= startDate);
            }

            if (endDate != null)
            {
                result = result.Match(sportEvent => sportEvent.EndDate <= endDate);
            }

            return result.ToList();
        }

        public Event GetEvent(Guid id)
        {
            return _events.Find(sportEvent => sportEvent.Id == id).FirstOrDefault();
        }

        public Event CreateEvent(Event eventToCreate)
        {
            _events.InsertOne(eventToCreate);

            return eventToCreate;
        }
            
        public void UpdateEvent(Guid id, Event eventIn)
        {
           _events.ReplaceOne(sportEvent => sportEvent.Id == id, eventIn);
        }

        public void RemoveEvent(Guid id)
        {
            _events.DeleteOne(sportEvent => sportEvent.Id == id);
        }
    }
}
