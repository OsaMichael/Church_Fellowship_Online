using GospelWorld.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GospelWorld.Models
{
    public class DeptListViewModel
    {
        public IPagedList<Department> Departments { get; set; }
        public IEnumerable<Department> AllDepartment { get; set; } = Enumerable.Empty<Department>();
    }
}