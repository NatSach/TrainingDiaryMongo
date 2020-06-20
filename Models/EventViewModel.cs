using System;
using System.Collections.Generic;

namespace TrainigDiaryMongo.Models
{
    public class EventViewModel
    {
        public List<Event> SportEvents { get; set; }
        public List<EventTypeViewModel> EventTypes { get; set; }
        public string SearchName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
