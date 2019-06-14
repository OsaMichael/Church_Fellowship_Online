using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GospelWorld.Entities
{
    public class Worker
    {
        [Key]
        public int WorkId { get; set; }
        public int? DeptId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherName { get; set; }
        public string WorkerName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }

       
        public virtual Department Department { get; set; }
        public virtual ICollection<Attendance> Attendancss { get; set; }


    }
}