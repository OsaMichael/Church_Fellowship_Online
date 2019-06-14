using GospelWorld.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GospelWorld.Models
{
    public class WorkerListViewModel
    {
        public IPagedList<WorkerModel> Workers { get; set; }
    }
}