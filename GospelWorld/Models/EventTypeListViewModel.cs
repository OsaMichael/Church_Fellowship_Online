using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GospelWorld.Models
{
    public class EventTypeListViewModel
    {
        public IEnumerable<EventTypeModel> EventTypes { get; set; } = Enumerable.Empty<EventTypeModel>();

    }
}