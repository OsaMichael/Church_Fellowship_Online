﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GospelWorld.Models
{
    public class DayModel
    {
        public int DayId { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
    }
}