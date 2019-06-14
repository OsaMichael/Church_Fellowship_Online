using GospelWorld.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GospelWorld.Models
{
    public class SermonViewModel
    {
        public IEnumerable<SermonModel> Sermons { get; set; }
        public IEnumerable<SermonCategory> SermonCategorss { get; set; }
        public string SermonCat { get; set; }


        public SermonViewModel()
        {

        }

        public SermonViewModel(Sermon sermon)
        {
            this.Assign(sermon);
        }


    }
}