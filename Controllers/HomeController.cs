using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using TrainigDiaryMongo.Models;
using TrainigDiaryMongo.Services;

namespace TrainigDiaryMongo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TrainingService _service;

        public HomeController(ILogger<HomeController> logger, TrainingService service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult Index()
        {
            List<Event> events = _service.GetEvents();

            List<CalendarEvent> calendarEvents = events.Select(x => new CalendarEvent(x)).ToList();

            return View(calendarEvents);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
