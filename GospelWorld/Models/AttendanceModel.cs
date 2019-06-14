using GospelWorld.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GospelWorld.Models
{
    public class AttendanceModel
    {
        public int AtendId { get; set; }
        public int WorkId { get; set; }

        public bool IsChecked { get; set; }
        public DateTime? Date { get; set; } = DateTime.Now;


        public virtual WorkerModel Worker { get; set; }
    }
}
