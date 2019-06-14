using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GospelWorld.Models
{
    public class EventListViewModel
    {
        public IPagedList<EventModel> Events { get; set; }
    }
}