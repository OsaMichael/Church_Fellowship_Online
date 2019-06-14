using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GospelWorld.Entities
{
    public class Department
    {
        [Key]
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public string Description { get; set; }
         
        public string DeptLocation { get; set; }
        public string ImageUrl { get; set; }
        public string DeptLeaderName { get; set; }
        public string DeptMeeting { get; set; }
        public string LeaderImageUrl { get; set; }
        public string LeaderImageThumbnailUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        //public HttpPostedFileBase DeptLeaderImageFile { get; set; }
        //public HttpPostedFileBase ImageFile { get; set; }

        public bool Done { get; set; } = false;
        public ICollection<Worker> Workers { get; set; }
        //public string MeetingDay { get; set; }


    }
}