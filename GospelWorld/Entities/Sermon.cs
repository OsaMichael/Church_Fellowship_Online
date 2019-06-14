using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GospelWorld.Entities
{
    public class Sermon
    {
        [Key]
        public int SermId { get; set; }
        public int? CatId { get; set; }

        public string PreacherName { get; set; }
        public string SermonText { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string SermonTitle { get; set; }
        public DateTime SermonDate { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        //public string SermonvideoUrl { get; set; }
        // public string SermonvideoThumbnail { get; set; }

        public bool IsLiked { get; set; }
        public virtual SermonCategory SermonCategory { get; set; }
  


    }
}