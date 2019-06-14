using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GospelWorld.Entities
{
    public class EventType
    {
        [Key]
        public int ETId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
   
        public virtual ICollection<Event> Events { get; set; }

}
}