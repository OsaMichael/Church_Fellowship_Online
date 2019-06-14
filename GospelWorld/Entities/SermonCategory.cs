using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GospelWorld.Entities
{
    public class SermonCategory
    {
        [Key]
        public int CatId { get; set; }
        public string SermonName { get; set; }
        public string SermonType { get; set; }
        public string SermonCat { get; set; }
        public string SermonDescription { get; set; }
      //  public List<Sermon> Sermons { get; set; }
        public virtual ICollection<Sermon> Sermons { get; set; }

    }
}