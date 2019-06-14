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
        public IPagedList<DepartmentModel> Departments { get; set; }
        public IEnumerable<DepartmentModel> AllDepartment { get; set; } = Enumerable.Empty<DepartmentModel>();
    }
}