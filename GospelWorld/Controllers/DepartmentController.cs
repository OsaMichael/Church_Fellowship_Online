using GospelWorld.Interface;
using GospelWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GospelWorld.Controllers
{
    public class DepartmentController : Controller
    {
        private IDepartmentService _service;
        private ApplicationDbContext context = new ApplicationDbContext();
        public DepartmentController(IDepartmentService service)
        {
            _service = service;
        }
        // GET: Department
        [HttpGet]
        public ActionResult DepartmentCorner()
        {
            // ViewBag.profile = context.Departments.ToList();
            var results = _service.GetDepartments();
           // var connect = context.Departments.ToList();
            var dvn = new DeptListViewModel
            {
                AllDepartment = results
            };

            //if (TempData["message"] != null)
            //{
            //    ViewBag.Success = (string)TempData["message"];
            //}

            //var results = _service.GetDepartments();
            return View(dvn);
        }

        [HttpGet]
        public ActionResult CreateDeptt ()
        {
            return View();
        }
        public ActionResult CreateDeptt(DepartmentModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _service.CreateDept(model);
                if (result == true)
                {
                    TempData["message"] = $"Department{model.DeptName} was successfully added!";
                    return RedirectToAction("Index");
                }

            }

            return View(model);

        }
    }
}