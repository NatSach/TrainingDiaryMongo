using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainigDiaryMongo.Models;
using TrainigDiaryMongo.Services;

namespace TrainigDiaryMongo.Controllers
{
    public class EventController : Controller
    {
        private readonly TrainingService _service;
        private readonly UserManager<ApplicationUser> _userManager;

        public EventController(TrainingService service, UserManager<ApplicationUser> userManager)
        {
            _service = service;
            _userManager = userManager;
        }

        public IActionResult Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportEvent = _service.GetEvent(id);
            if (sportEvent == null)
            {
                return NotFound();
            }

            return View(sportEvent);
        }

        public IActionResult Index(string name = null, string types = null, DateTime? startDate = null, DateTime? endDate = null)
        {
            List<Event> sportEvents = _service.GetEvents(name, types, startDate, endDate);
            List<EventType> eventTypes = _service.GetEventTypes();

            EventViewModel eventViewModel = new EventViewModel()
            {
                SportEvents = sportEvents,
                EventTypes = eventTypes.Select(x => new EventTypeViewModel() { Name = x.Name, IsSelected = types == null ? true : types.Contains(x.Name) }).ToList(),
                SearchName = name,
                StartDate = startDate,
                EndDate = endDate
            };

            return View(eventViewModel);
        }

        public IActionResult Create()
        {
            CreateEventViewModel createEventViewModel = new CreateEventViewModel()
            {
                NewEvent = new Event()
                {
                    StartDate = DateTime.Today,
                    EndDate = DateTime.Today
                },
                EventTypes = _service.GetEventTypes().Select(x => new SelectListItem(x.Name, x.Name)).ToList()
            };

            return View(createEventViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEventViewModel sportEvent)
        {
            if (ModelState.IsValid)
            {
                _service.CreateEvent(sportEvent.NewEvent);

                return RedirectToAction("Index", "Event");
            }
            return View(sportEvent);
        }

        [HttpPost]
        public IActionResult SignUpForEvent(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportEvent = _service.GetEvent(id);
            if (sportEvent == null)
            {
                return NotFound();
            }

            string email = _userManager.GetUserName(User);
            string firstName = string.Empty;
            string lastName = string.Empty;

            if(!sportEvent.Participants.Any(x => x.Email == email))
            {
                sportEvent.Participants.Add(new Person() { Email = email });
                _service.UpdateEvent(id, sportEvent);
            }

            return RedirectToAction("Details", new { id = id });
        }

        public IActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportEvent = _service.GetEvent(id);
            if (sportEvent == null)
            {
                return NotFound();
            }

            CreateEventViewModel createEventViewModel = new CreateEventViewModel()
            {
                NewEvent = sportEvent,
                EventTypes = _service.GetEventTypes().Select(x => new SelectListItem(x.Name, x.Name)).ToList()
            };

            return View(createEventViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CreateEventViewModel sportEvent)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateEvent(sportEvent.NewEvent.Id, sportEvent.NewEvent);

                return RedirectToAction("Index", "Event");
            }
            return View(sportEvent);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportEvent = _service.GetEvent(id);
            if (sportEvent == null)
            {
                return NotFound();
            }

            return View(sportEvent);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            _service.RemoveEvent(id);

            return RedirectToAction("Index", "Event");
        }
    }
}
