using GospelWorld.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GospelWorld.Models
{
    public class EventTypeModel
    {
        public int ETId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "EVent Type")]
        public string Type { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        public string Name { get; set; }
        public bool Done { get; set; } = false;
       // public virtual ICollection<EventModel> Events { get; set; }

        public EventTypeModel()
        {

        }

        public EventTypeModel(EventType eventType)
        {
            this.Assign(eventType);
        }
    }
}