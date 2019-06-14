using GospelWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GospelWorld.Interface
{
    public interface IDepartmentService
    {
        bool CreateDept(DepartmentModel model);
        List<DepartmentModel> GetDepartments();
        //   bool UpdateDept(DepartmentModel model);
        DepartmentModel UpdateDept(DepartmentModel model);
        DepartmentModel GetDepartmentById(int id);
        DepartmentModel DepatDetails(int id);
        
    }
}