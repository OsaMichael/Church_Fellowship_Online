using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GospelWorld.Entities
{
    public class Attendance
    {
        [Key]
        public int AtendId { get; set; }
        public int? WorkId { get; set; }
 
        public bool IsChecked { get; set; }
        public DateTime? Date { get; set; } = DateTime.Now;


        public virtual Worker Workers { get; set; }


    }
}
