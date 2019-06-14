using GospelWorld.Atrributes;
using GospelWorld.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GospelWorld.Models
{
    public class HomeViewModel
    {

        public IEnumerable<Sermon> Sermons { get; set; }
        public IEnumerable<Event> Events { get; set; }
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<Member> Members { get; set; }
        public int Nextevent { get; set; }
        //  public IEnumerable<IDepartment> AllDepartment { get; set; } = Enumerable.Empty<IDepartment>();

        public string RecentSermon { get; set; }
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        [FileTypes("jpg,jpeg,png")]
        public HttpPostedFileBase ImageFile { get; set; }


    }
}