using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GospelWorld.Entities
{
    public partial class Event
    {
        [Key]
        public int EventId { get; set; }
       // public int ETId { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string EventTheme { get; set; }
        public string EventType { get; set; }
        public string EventLocation { get; set; }
        public string EventImageThumbnailUrl { get; set; }
        public string EventImageUrl { get; set; }
        public string EventDescription { get; set; }
        //public virtual  EventType Eventtype { get; set; }

    }
}