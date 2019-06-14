using GospelWorld.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GospelWorld.Models
{
    public class SermonIndexViewModel
    {
        public SermonModel sermon { get; set; }
        public string ReturnUrl { get; set; }
    }
}