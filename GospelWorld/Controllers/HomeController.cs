using GospelWorld.Interface;
using GospelWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GospelWorld.Controllers
{
    public class HomeController : Controller
    {

        private ApplicationDbContext _context;
        // private MailService _mailService;
        private IMemberServices _memberServices;
        private IDepartmentService _dtservice;
        private IEventServices _event;
        private ISermonServices _sermonServices;
        private IWorkerServices _workServ;
        public HomeController(IMemberServices services, IDepartmentService departmentService, IWorkerServices worker, IMemberServices member, ISermonServices sermon, ApplicationDbContext applicationDb, IEventServices eventServices)
        {
            _memberServices = services;
            _dtservice = departmentService;
            _event = eventServices;
            _sermonServices = sermon;
            _workServ = worker;
            _context = applicationDb;
        }
        public ActionResult Index()
        {
            var members = _context.Members.ToList(); ;
            var upcomingevent = _context.Events.ToList(); ;
            var sermon = _context.Sermons.ToList();
            var deptimg = _context.Departments.ToList();

            var hvm = new HomeViewModel
            {
                Events = upcomingevent,
                Sermons = sermon,
                Departments = deptimg,
                Members = members
            };
            return View(hvm);
        }

        //public ActionResult About()
        //{
        //    var departmentleaders = _dtservice.GetDepartments();
        //    var dvm = new DepartmentModel
        //    {
        //       DeptLeaderName   = departmentleaders
        //    };
        //    return View(dvm); ;
        //}


        public ActionResult Contact()
        {

            return View();
        }


        public ActionResult NatioalProgramme()
        {
            var currentdepartment = _dtservice.GetDepartments();

            var dvm = new DeptListViewModel
            {

                AllDepartment = currentdepartment

            };
            return View(dvm);

        }
    }
}