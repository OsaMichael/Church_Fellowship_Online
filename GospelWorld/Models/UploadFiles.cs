using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GospelWorld.Models
{
    public class UploadFiles
    {
        public HttpPostedFileBase[] files { get; set; }
    }
}