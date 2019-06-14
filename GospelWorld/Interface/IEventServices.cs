using GospelWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GospelWorld.Interface
{
    public interface IEventServices
    {
        bool CreateEvent(EventModel model);
        List<EventModel> GetEvents();
        bool UpdateEvent(EventModel model);
        EventModel GetEventById(int id);
        bool DeleteEvent(int id);
        List<EventTypeModel> GetEventTypes();
    }
}