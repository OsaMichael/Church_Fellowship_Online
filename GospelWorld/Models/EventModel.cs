using GospelWorld.Atrributes;
using GospelWorld.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GospelWorld.Models
{
    public class EventModel
    {
        
        public int EventId { get; set; }
       // public int ETId { get; set; }
      //  public IEnumerable<EventModel> Events { get; set; }
        [Display(Name = "Event Name")]
        public string EventName { get; set; }

        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        [Display(Name = "Event Date")]
        public DateTime EventDate { get; set; }
        [Display(Name = "Event Theme")]
        public string EventTheme { get; set; }
        [Display(Name = "Event Location")]
        public string EventLocation { get; set; }
        public string EventImageThumbnailUrl { get; set; }
        [FileTypes("jpg,jpeg,png")]

        public HttpPostedFileBase EventImageFile { get; set; }
        [Display(Name = "Event Poster")]
        public string EventImageUrl { get; set; }
        [Display(Name = "Category")]
        public string EventType { get; set; }

        [Required]
        [Display(Name = "Event Description")]
        public string EventDescription { get; set; }
        public bool Done { get; set; } = false;

        //public virtual EventTypeModel Eventtype { get; set; }


        public EventModel()
        {
            new EventTypeModel();
        }

        public EventModel(Event devent)
        {
            this.Assign(devent);
            //Eventtype = new EventTypeModel();
        }

        public Event Create(EventModel model)
        {
            return new Event
            {
                //ETId = model.ETId,
                EventType = model.EventType,
                EventDescription = model.EventDescription,
                EventDate = DateTime.Now,
                 EventLocation = model.EventLocation,
                  EventName = model.EventName,
                   EventTheme = model.EventTheme,
                    EventImageThumbnailUrl = model.EventImageUrl,
               // EventImageThumbnailUrl = model.EventImageThumbnailUrl,
                     EventImageUrl = model.EventImageUrl
                   
                   
                    
            };
        }
        public Event Edit(Event entity, EventModel model)
        {

            entity.EventLocation = model.EventLocation;
            entity.EventName = model.EventName;
            entity.EventTheme = model.EventTheme;
            entity.EventDescription = model.EventDescription;
            entity.EventId = model.EventId;
            //entity.ETId = model.ETId;
            entity.EventDate = DateTime.Now;
            return entity;
        }
    }
}
