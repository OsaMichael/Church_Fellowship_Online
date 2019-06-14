using GospelWorld.Entities;
using GospelWorld.Interface;
using GospelWorld.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GospelWorld.Controllers
{
    public class WorkerController : Controller
    {
        private ApplicationDbContext _context;
        private IWorkerServices _workServ;
        private IDepartmentService _dptservice;
        public WorkerController( IWorkerServices workerServices, ApplicationDbContext context, IDepartmentService department)
        {
            _context = context;
            _workServ = workerServices;
            _dptservice = department;
        }

        // GET: Worker
        //public ActionResult Index()
        //{

        //    return View();
        //}
        [HttpGet]
        public ActionResult JoinWorker()
        {
            //var dept = _context.Departments.ToList().Select(r => r.DeptName);


            //ViewBag.Department = new SelectList(dept);
            ViewBag.Department = new SelectList(_dptservice.GetDepartments(), "DeptId", "DeptName");

            return View(new WorkerModel());
        }
       // [ValidateInput(false)]
        [HttpPost]
        public ActionResult JoinWorker( WorkerModel model)
        {
            if(ModelState.IsValid)
            {
                ViewBag.Department = new SelectList(_dptservice.GetDepartments(), "DeptId", "DeptName");
             //   var dept = _context.Departments.ToList().Select(r => r.DeptName);
                //ViewBag.Department = new SelectList(dept);
                //  ViewBag.Department = new SelectList(dept);

                // var dept = _workServ.CreateWorker(model);
                string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                string extension = Path.GetExtension(model.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssffff") + extension;
                model.ImageUrl = fileName;
                fileName = Path.Combine(Server.MapPath("~/Content/Images/"), fileName);

                model.ImageFile.SaveAs(fileName);


                var result = _workServ.CreateWorker(model);
                //var worker = new Worker
                //{
                //    //WorkerName = model.FirstName + " " + model.LastName,
                //    FirstName = model.FirstName,
                //    LastName = model.LastName,
                //    Address = model.Address,
                //    DeptId = model.DeptId,
                //    ImageUrl = model.ImageUrl,
                //    ImageThumbnailUrl = model.ImageUrl,
                //    PhoneNumber = model.PhoneNumber
                //};
                if (result != null)
                {
                    //_context.Workers.Add(worker);
                    //_context.SaveChanges();
                    TempData["message"] = string.Format("{0} has been saved.", model.FirstName);
                    return RedirectToAction("index");
                }
                else
                {
                    var deptl = _dptservice.GetDepartments().Select(r => r.DeptName);
                    ViewBag.Department = new SelectList(deptl);
               
                }

            }


            return View(model);
        }
    }
}