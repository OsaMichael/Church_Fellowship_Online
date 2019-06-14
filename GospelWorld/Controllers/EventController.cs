using GospelWorld.Entities;
using GospelWorld.Interface;
using GospelWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GospelWorld.Controllers
{
    public class EventController : Controller
    {
        private ApplicationDbContext context;
        private IEventServices _event;
        public EventController (IEventServices @event)
        {
            context = new ApplicationDbContext();
            _event = @event;
        }

        // GET: Event
        public ActionResult EventDetails(int id)
        {
            var _eventtt = _event.GetEventById(id);
            var singleevent = _eventtt;
            return View(singleevent);
        }

        public ActionResult UpcomingEvents()
        {

            ViewBag.events = context.Events;

            var upcomingevent = _event.GetEvents();
            var hvm = upcomingevent;
          
            return View(hvm);
        }

        public ActionResult EventCalendar()
        {
            var eventcalender = _event.GetEvents();
            ViewBag.events = eventcalender;
            var evm = eventcalender;
            return View(evm);
        }
    }
}