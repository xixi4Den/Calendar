using System;
using System.Web;
using System.Web.Mvc;
using Calendar.Business;
using Calendar.Models;
using Microsoft.AspNet.Identity;

namespace Calendar.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService eventService;

        public EventController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        [Authorize]
        public ActionResult List(int year, int month, int day)
        {
            var date = new DateTime(year, month, day);
            var viewModel = eventService.GetEventsOnDate(date, User.Identity.GetUserId());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(EventViewModel newEvent)
        {
            try
            {
                eventService.CreateEvent(newEvent);
                return Json(true);
            }
            catch(Exception e)
            {
                throw new HttpException(500, "");
            }
        }

        [HttpPost]
        public ActionResult Edit(EventViewModel oldEvent)
        {
            try
            {
                eventService.UpdateEvent(oldEvent);
                return Json(true);
            }
            catch (Exception e)
            {
                throw new HttpException(500, "");
            }
        }
    }
}
