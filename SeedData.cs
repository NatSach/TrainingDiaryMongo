using System;
using System.Collections.Generic;
using System.Drawing;
using TrainigDiaryMongo.Models;
using TrainigDiaryMongo.Services;

namespace TrainigDiaryMongo
{
    public class SeedData
    {
        private readonly TrainingService _service;

        public SeedData(TrainingService service)
        {
            _service = service;
        }

        private void CreateEventTypes()
        {
            List<EventType> eventTypes = new List<EventType>()
            {
                new EventType("competition"),
                new EventType("training"),
                new EventType("casual")
            };

            foreach (var eventType in eventTypes)
            {
                _service.CreateEventType(eventType);
            }
        }

        private void CreateEvents()
        {
            List<Event> events = new List<Event>();

            Event sportEvent = new Event()
            {
                EventName = "Maraton",
                StartDate = new DateTime(2020, 06, 18, 10, 00, 00, 00, DateTimeKind.Local),
                EndDate = new DateTime(2020, 06, 22, 16, 30, 00, 00, DateTimeKind.Local),
                CalendarColor = ColorTranslator.ToHtml(Color.Blue),
                Location = "Białystok",
                Type = "competition",
                Description = @"Nazwa pochodzi od miejscowości Maraton w Grecji. Według Herodota po zwycięskiej dla Greków bitwie z Persami pod Maratonem w 490 p.n.e., armia perska zaokrętowała i wypłynęła w kierunku bezbronnych Aten. Widząc to, Grecy udali się co sił w nogach do miasta, przybywając praktycznie równocześnie z okrętami perskimi[1].
                                Bieg ten stał się podstawą romantycznych historii, według których posłaniec Filippides pobiegł do Aten, by opowiedzieć o zwycięstwie i poinformować Ateńczyków, że płynie ku nim flota perska. Po przekazaniu tej wiadomości padł martwy. W 1879 r. brytyjski poeta Robert Browning napisał na kanwie tej historii znany wiersz Filippides (ang. Pheidippides).
                                Michel Bréal, francuski filolog, zainspirowany historią marszu zasugerował Pierre'owi de Coubertinowi, by włączył bieg na dystansie odpowiadającym odległości z Maratonu do Aten do programu pierwszych nowożytnych igrzysk olimpijskich w Atenach.",
                Organiser = new Person()
                {
                    FirstName = "Jan",
                    LastName = "Kowalski",
                    Email = "jan.kowalski@mail.com"
                },
                Participants = new List<Person>()
                {
                    new Person()
                    {
                        FirstName = "Adam",
                        LastName = "Nowak",
                        Email = "adam.nowak@mail.com"
                    },
                    new Person()
                    {
                        FirstName = "Anna",
                        LastName = "Gąbka",
                        Email = "anna.gabka@mail.com"
                    }
                }
            };

            events.Add(sportEvent);

            sportEvent = new Event()
            {
                EventName = "Nocne bieganie",
                StartDate = new DateTime(2020, 06, 17, 21, 00, 00, 00, DateTimeKind.Local),
                EndDate = new DateTime(2020, 06, 18, 10, 45, 00, 00, DateTimeKind.Local),
                CalendarColor = ColorTranslator.ToHtml(Color.Green),
                Location = "Białystok",
                Type = "casual"
            };
            events.Add(sportEvent);

            sportEvent = new Event()
            {
                EventName = "Mistrzostwa Łowicza",
                StartDate = new DateTime(2020, 06, 1, 8, 00, 00, 00, DateTimeKind.Local),
                EndDate = new DateTime(2020, 06, 3, 20, 45, 00, 00, DateTimeKind.Local),
                CalendarColor = ColorTranslator.ToHtml(Color.Blue),
                Location = "Łowicz",
                Type = "competition"
            };
            events.Add(sportEvent);

            sportEvent = new Event()
            {
                EventName = "Trening z Adamem Małyszem",
                StartDate = new DateTime(2020, 06, 1, 10, 00, 00, 00, DateTimeKind.Local),
                EndDate = new DateTime(2020, 06, 1, 14, 45, 00, 00, DateTimeKind.Local),
                CalendarColor = ColorTranslator.ToHtml(Color.Green),
                Location = "Katowice",
                Type = "casual"
            };
            events.Add(sportEvent);

            sportEvent = new Event()
            {
                EventName = "Mistrzostwa Białegostoku",
                StartDate = new DateTime(2020, 06, 4, 8, 00, 00, 00, DateTimeKind.Local),
                EndDate = new DateTime(2020, 06, 6, 20, 45, 00, 00, DateTimeKind.Local),
                CalendarColor = ColorTranslator.ToHtml(Color.Blue),
                Location = "Białystok",
                Type = "competition"
            };
            events.Add(sportEvent);

            sportEvent = new Event()
            {
                EventName = "Mistrzostwa Białegostoku",
                StartDate = new DateTime(2019, 06, 4, 8, 00, 00, 00, DateTimeKind.Local),
                EndDate = new DateTime(2019, 06, 6, 20, 45, 00, 00, DateTimeKind.Local),
                CalendarColor = ColorTranslator.ToHtml(Color.Blue),
                Location = "Białystok",
                Type = "competition"
            };
            events.Add(sportEvent);

            sportEvent = new Event()
            {
                EventName = "Mistrzostwa Warszawy",
                StartDate = new DateTime(2020, 06, 2, 8, 00, 00, 00, DateTimeKind.Local),
                EndDate = new DateTime(2020, 06, 5, 20, 45, 00, 00, DateTimeKind.Local),
                CalendarColor = ColorTranslator.ToHtml(Color.Blue),
                Location = "Warszawa",
                Type = "competition"
            };
            events.Add(sportEvent);

            sportEvent = new Event()
            {
                EventName = "Mistrzostwa Warszawy",
                StartDate = new DateTime(2019, 06, 2, 8, 00, 00, 00, DateTimeKind.Local),
                EndDate = new DateTime(2019, 06, 5, 20, 45, 00, 00, DateTimeKind.Local),
                CalendarColor = ColorTranslator.ToHtml(Color.Blue),
                Location = "Warszawa",
                Type = "competition"
            };
            events.Add(sportEvent);

            sportEvent = new Event()
            {
                EventName = "Mistrzostwa świata",
                StartDate = new DateTime(2020, 06, 14, 8, 00, 00, 00, DateTimeKind.Local),
                EndDate = new DateTime(2020, 07, 5, 20, 45, 00, 00, DateTimeKind.Local),
                CalendarColor = ColorTranslator.ToHtml(Color.Blue),
                Location = "Paryż",
                Type = "competition"
            };
            events.Add(sportEvent);

            sportEvent = new Event()
            {
                EventName = "Mistrzostwa świata",
                StartDate = new DateTime(2019, 06, 14, 8, 00, 00, 00, DateTimeKind.Local),
                EndDate = new DateTime(2019, 07, 5, 20, 45, 00, 00, DateTimeKind.Local),
                CalendarColor = ColorTranslator.ToHtml(Color.Blue),
                Location = "Katar",
                Type = "competition"
            };
            events.Add(sportEvent);

            sportEvent = new Event()
            {
                EventName = "Trening - sprint",
                StartDate = new DateTime(2020, 06, 18, 10, 00, 00, 00, DateTimeKind.Local),
                EndDate = new DateTime(2020, 06, 22, 16, 30, 00, 00, DateTimeKind.Local),
                CalendarColor = ColorTranslator.ToHtml(Color.Gold),
                Location = "Białystok",
                Type = "training"
            };
            events.Add(sportEvent);

            sportEvent = new Event()
            {
                EventName = "Trening wytrzymałościowy",
                StartDate = new DateTime(2020, 06, 2, 10, 00, 00, 00, DateTimeKind.Local),
                EndDate = new DateTime(2020, 06, 2, 16, 30, 00, 00, DateTimeKind.Local),
                CalendarColor = ColorTranslator.ToHtml(Color.Gold),
                Location = "Bydgoszcz",
                Type = "training"
            };
            events.Add(sportEvent);

            sportEvent = new Event()
            {
                EventName = "Trening górski",
                StartDate = new DateTime(2020, 06, 22, 10, 00, 00, 00, DateTimeKind.Local),
                EndDate = new DateTime(2020, 06, 24, 22, 00, 00, 00, DateTimeKind.Local),
                CalendarColor = ColorTranslator.ToHtml(Color.Gold),
                Location = "Zakopane",
                Type = "training"
            };
            events.Add(sportEvent);

            sportEvent = new Event()
            {
                EventName = "Maraton",
                StartDate = new DateTime(2020, 06, 18, 14, 30, 00, 00, DateTimeKind.Local),
                EndDate = new DateTime(2020, 06, 22, 20, 15, 00, 00, DateTimeKind.Local),
                CalendarColor = ColorTranslator.ToHtml(Color.Gold),
                Location = "Gdynia",
                Type = "training"
            };
            events.Add(sportEvent);

            sportEvent = new Event()
            {
                EventName = "Rodzinne bieganie",
                StartDate = new DateTime(2020, 06, 20, 14, 30, 00, 00, DateTimeKind.Local),
                EndDate = new DateTime(2020, 06, 21, 14, 30, 00, 00, DateTimeKind.Local),
                CalendarColor = ColorTranslator.ToHtml(Color.Green),
                Location = "Suwałki",
                Type = "casual"
            };
            events.Add(sportEvent);

            sportEvent = new Event()
            {
                EventName = "Spotkanie Jagielloni Białystok",
                StartDate = new DateTime(2020, 06, 19, 17, 30, 00, 00, DateTimeKind.Local),
                EndDate = new DateTime(2020, 06, 19, 20, 30, 00, 00, DateTimeKind.Local),
                CalendarColor = ColorTranslator.ToHtml(Color.Green),
                Location = "Białystok",
                Type = "casual"
            };
            events.Add(sportEvent);

            sportEvent = new Event()
            {
                EventName = "Akcja charytatywna - Pomoc mierzona kilometrami",
                StartDate = new DateTime(2020, 07, 4, 9, 30, 00, 00, DateTimeKind.Local),
                EndDate = new DateTime(2020, 07, 5, 20, 30, 00, 00, DateTimeKind.Local),
                CalendarColor = ColorTranslator.ToHtml(Color.Green),
                Location = "Poznań",
                Type = "casual"
            };
            events.Add(sportEvent);

            sportEvent = new Event()
            {
                EventName = "Akcja charytatywna - Pomoc mierzona kilometrami",
                StartDate = new DateTime(2020, 07, 4, 9, 30, 00, 00, DateTimeKind.Local),
                EndDate = new DateTime(2020, 07, 5, 20, 30, 00, 00, DateTimeKind.Local),
                CalendarColor = ColorTranslator.ToHtml(Color.Green),
                Location = "Białystok",
                Type = "casual"
            };
            events.Add(sportEvent);

            sportEvent = new Event()
            {
                EventName = "Akcja charytatywna - Pomoc mierzona kilometrami",
                StartDate = new DateTime(2020, 07, 4, 9, 30, 00, 00, DateTimeKind.Local),
                EndDate = new DateTime(2020, 07, 5, 20, 30, 00, 00, DateTimeKind.Local),
                CalendarColor = ColorTranslator.ToHtml(Color.Green),
                Location = "Warszawa",
                Type = "casual"
            };
            events.Add(sportEvent);

            foreach (var eventToCreate in events)
            {
                _service.CreateEvent(eventToCreate);
            }
        }

        public void Init()
        {
            CreateEventTypes();
            CreateEvents();
        }
    }
}
