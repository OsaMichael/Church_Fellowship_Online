using GospelWorld.Entities;
using GospelWorld.Interface;
using GospelWorld.Managers;
using GospelWorld.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GospelWorld.Controllers
{
    //[Authorize]

    public class AdminController : Controller
    {
        private ApplicationDbContext _context;
         private MailService _mailService;
        private IMemberServices _memberServices;
        private IDepartmentService _dtservice;
        private IEventServices _event;
        private ISermonServices _sermonServices;
        private IWorkerServices _workServ;
        private ISermonCategoryServ _sermonCategory;

        public AdminController(IMemberServices services, IDepartmentService departmentService, IWorkerServices worker, IMemberServices member, ISermonServices sermon, ApplicationDbContext applicationDb ,IEventServices eventServices, ISermonCategoryServ sermonCategory)
        {
            _memberServices = services;
            _dtservice = departmentService;
            _event = eventServices;
            _sermonServices = sermon;
            _workServ = worker;
            _context = applicationDb;
            _sermonCategory = sermonCategory;
        }
        // GET: Admin
        public ActionResult Index()

        {
            ViewBag.DepartmentCount = _dtservice.GetDepartments().Count();
            ViewBag.EventCount = _event.GetEvents().Count();
            ViewBag.SermonCount = _sermonServices.GetSermons().Count();
            ViewBag.WorkerCount = _workServ.GetWorkers().Count();
            ViewBag.MemberCount = _memberServices.GetMembers().Count();
            return View();
        }
        [HttpGet]
        public ActionResult Member()
        {
            var member = _memberServices.GetMembers().Select(r => r.FirstName + " " + r.LastName);
            return View(new MemberModel());
        }
        [HttpPost]
        public ActionResult Member(MemberModel model)
        {
            if(ModelState.IsValid)
            {
                var member = _memberServices.GetMembers().Where(r => r.LastName == model.LastName).FirstOrDefault();
                string fileName = Path.GetFileNameWithoutExtension(model.MemeberImageThumbnailUrl.FileName);
                string extension = Path.GetExtension(model.MemeberImageThumbnailUrl.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssffff") + extension;
                model.MemberImageUrl = fileName;
                fileName = Path.Combine(Server.MapPath("~/Content/Images/"), fileName);

                model.MemeberImageThumbnailUrl.SaveAs(fileName);

                var result = _memberServices.CreateMemb(model);

                
                TempData["message"] = string.Format("{0} has been saved.", model.FirstName);
                return RedirectToAction("Index");
            }
            else
            {
                var member = _memberServices.GetMembers().Select(r => r.FirstName + " " + r.LastName);
                return View(model);
            }
          
        }
        [HttpGet]
        public ActionResult MemberList(int? page)
        {
            var pageSize = 10;
            var members = _memberServices.GetMembers().ToList().ToPagedList(page ?? 1, pageSize);
            var mvm = new MemberModel
            {
                //passing a list from the Membermodel
                Members = members
            };

            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;
            return View(mvm);
        }
        [HttpGet]
        public ActionResult AddSermon()
        {
            var sermoncategory = _context.SermonCategories.Select(r => r.SermonName);
            ViewBag.SermonCategory = new SelectList(sermoncategory);

            return View(new SermonModel());
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult AddSermon(SermonModel model)
        {
            if(ModelState.IsValid)
            {
                var sermoncat = _context.SermonCategories.Where(s => s.SermonName == model.SermonCategoryName).FirstOrDefault();
                string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                string extension = Path.GetExtension(model.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssffff") + extension;
                model.ImageUrl = fileName;
                fileName = Path.Combine(Server.MapPath("~/Content/Images/"), fileName);
                model.ImageFile.SaveAs(fileName);

                // 
                var addsermon = new Sermon
                {
                    SermonDate = model.SermonDate,
                    CatId = model.CatId,
                    SermonTitle = model.SermonTitle,
                    SermonText = model.SermonText,
                    PreacherName = model.PreacherName,
                    LongDescription = model.LongDescription,
                    ShortDescription = model.ShortDescription,
                    SermonCategory = sermoncat,
                    ImageUrl = model.ImageUrl,
                    ImageThumbnailUrl = model.ImageUrl,

                    //SermonvideoUrl=sv.SermonvideoUrl,
                    //SermonvideoThumbnail=sv.SermonvideoUrl

                };
                _context.Sermons.Add(addsermon);
                _context.SaveChanges();
                TempData["message"] = string.Format("{0} has been saved.", model.SermonTitle);
                return RedirectToAction("SermonList");
                //  var result = _sermonServices.CreatSermon(model);

            }
            else
            {
                var sermoncategory = _context.SermonCategories.Select(r => r.SermonName);
                ViewBag.SermonCategory = new SelectList(sermoncategory);
                return View(model);
            }
        }
        [HttpGet]
        public ActionResult AddEvent()
        {
            // var eventtype = _event.GetEvents().Select(r => r.EventName);

            // ViewBag.Events = new SelectList(_context.Eventtypes, "EventTypId", "Name");
            ViewBag.Events = new SelectList(_event.GetEventTypes(), "ETId", "Name");
            //  ViewBag.Events = new SelectList(eventtype);
            return View(new EventModel());
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult AddEvent(EventModel model)
        {

          

            if (ModelState.IsValid)
            {

                // ViewBag.Events = new SelectList(_context.Eventtypes, "EventTypId", "Name");

                ViewBag.Events = new SelectList(_event.GetEventTypes(), "ETId", "Name");

                var eventtype = _context.Eventtypes.Where(r => r.Name == model.EventName).FirstOrDefault();
                string fileName = Path.GetFileNameWithoutExtension(model.EventImageFile.FileName);
                string extension = Path.GetExtension(model.EventImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssffff") + extension;
                model.EventImageUrl = fileName;
                fileName = Path.Combine(Server.MapPath("~/Content/Images/"), fileName);
                model.EventImageFile.SaveAs(fileName);

                // var result = _event.CreateEvent(model);

                var result = _event.CreateEvent(model);

                //var addevent = new Event
                //{
                //    EventDate = model.EventDate,
                //    EventName = model.EventName,
                //    EventTheme = model.EventTheme,
                //    EventDescription = model.EventDescription,
                //    EventImageUrl = model.EventImageUrl,
                //    EventLocation = model.EventLocation,
                //    EventImageThumbnailUrl = model.EventImageUrl,
                //    Eventtype = eventtype
                //};
                //_context.Events.Add(addevent);
                //_context.SaveChanges();
                TempData["message"] = string.Format("{0} has been saved.", model.EventName);
                return RedirectToAction("EventList");
            }
            else
            {
                var eventtype = _context.Eventtypes.Select(r => r.Name);
                ViewBag.Events = new SelectList(eventtype);
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult EditSermon(int id)
        {
            var _sermon = _sermonServices.GetSermonById(id);
            var sermoncategories = _context.SermonCategories.ToList();
            var sermoncat = _sermon.SermonCategory;
            ViewBag.SermonCategories = new SelectList(sermoncategories, "SermonName", "SermonName", sermoncat.SermonName);

            var svm = new SermonModel
            {
                LongDescription = _sermon.LongDescription,
                ShortDescription = _sermon.ShortDescription,
                PreacherName = _sermon.PreacherName,
                SermonCategoryName = _sermon.SermonCategory.SermonName,
                SermonDate = _sermon.SermonDate,
                SermonText = _sermon.SermonText,
                SermonTitle = _sermon.SermonTitle,
                SermId = _sermon.SermId,
                ImageUrl = _sermon.ImageUrl

            };
            return View(svm);
        }
        [ValidateInput(false)]
        // [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult EditSermon(SermonModel svm)
        {
            if (ModelState.IsValid)
            {
                var sermon = _context.Sermons.Find(svm.SermId);
                var sermoncat = _context.SermonCategories.Where(s => s.SermonName == svm.SermonCategoryName).FirstOrDefault();
                if (sermon != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(svm.ImageFile.FileName);
                    string extension = Path.GetExtension(svm.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssffff") + extension;
                    svm.ImageUrl = fileName;
                    fileName = Path.Combine(Server.MapPath("~/Content/Images/"), fileName);         
                    
                    sermon.SermonText = svm.SermonText;
                    sermon.SermonTitle = svm.SermonTitle;
                    sermon.SermonDate = svm.SermonDate;
                    sermon.PreacherName = svm.PreacherName;
                    sermon.LongDescription = svm.LongDescription;
                    sermon.ShortDescription = svm.ShortDescription;
                    sermon.ImageUrl = svm.ImageUrl;
                    sermon.ImageThumbnailUrl = svm.ImageUrl;
                    
               
                    if (svm.ImageFile != null && svm.ImageFile.ContentLength > 0)
                    {
                        svm.ImageFile.SaveAs(fileName);
                    }
                    sermon.SermonCategory = sermoncat;
                    _context.SaveChanges();
                 
                    TempData["message"] = $"{sermon.SermonTitle} was successfully edited ";
                }
                return RedirectToAction("SermonList");

            }
            else
            {
                return View(svm);
            }
        }
          [HttpGet]
        public ActionResult EditWorker(int id)
        {
            var worker = _workServ.GetWorkerById(id);
            var deptt = _dtservice.GetDepartments();
          
            var dep = worker.Department;
            ViewBag.workerdept = new SelectList(deptt, "DeptName", "DeptName", dep.DeptName);
            var wvm = new WorkerModel
            {
                FirstName = worker.WorkerName,
                Address = worker.Address,
                DepartmentName = worker.Department.DeptName,
                PhoneNumber = worker.PhoneNumber,
                ImageUrl = worker.ImageUrl
            };
            return View(wvm);

        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult EditWorker(WorkerModel wvm)
        {
            if (ModelState.IsValid)
            {
                var worker = _workServ.GetWorkerById(wvm.WorkId);
                var dept = _dtservice.GetDepartments().Where(s => s.DeptName == wvm.DepartmentName).FirstOrDefault();
                if (worker != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(wvm.ImageFile.FileName);
                    string extension = Path.GetExtension(wvm.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssffff") + extension;
                    wvm.ImageUrl = fileName;
                    fileName = Path.Combine(Server.MapPath("~/Content/Images/"), fileName);

                    worker.WorkerName = wvm.FirstName + "" + wvm.LastName + "" + wvm.OtherName;
                    worker.PhoneNumber = wvm.PhoneNumber;
                    worker.Address = wvm.Address;
                    worker.ImageUrl = wvm.ImageUrl;
                    worker.ImageThumbnailUrl = wvm.ImageUrl;
                    if (wvm.ImageFile != null && wvm.ImageFile.ContentLength > 0)
                    {
                        wvm.ImageFile.SaveAs(fileName);
                    }
                    worker.Department = dept;

                    _context.SaveChanges();
                    
                    TempData["message"] = $"{worker.WorkerName} was successfully edited ";
                }
                return RedirectToAction("Index");

            }
            else
            {
                return View(wvm);
            }
        }
        public ActionResult DeleteWorker(int Id)
        {
            var worker = _workServ.GetWorkers().Where(s => s.WorkId == Id).FirstOrDefault();
            if (worker.ImageUrl != null)
            {
                var filepath = Server.MapPath(@"~/Content/Images");
                List<string> files = Directory.GetFiles(filepath).ToList();
                var fullpath = string.Empty;
                string filename = worker.ImageUrl;
                string realfilename = files.Where(i => i.Contains(filename)).FirstOrDefault();
                if (realfilename != null)
                {
                    fullpath = Path.Combine(Server.MapPath("~/Content/Images/"), realfilename);
                    if (System.IO.File.Exists(fullpath))
                    {
                        System.IO.File.Delete(fullpath);
                        var ImgMessage = $"the image:{fullpath} was also removed";
                    }
                }
            }
            if (worker != null)
            {
                _workServ.GetWorkers().Remove(worker);
                _context.SaveChanges();
                TempData["message"] = $"{worker.WorkerName} was successfully deleted.{Environment.NewLine}";
            }
            return RedirectToAction("WorkerList");
        }
        public ActionResult DeleteSermon(int Id)
        {
            var _sermon = _sermonServices.GetSermons().Where(s => s.SermId == Id).FirstOrDefault();
            if (_sermon.ImageUrl != null)
            {
                var filepath = Server.MapPath(@"~/Content/Images");
                List<string> files = Directory.GetFiles(filepath).ToList();
                var fullpath = string.Empty;
                string filename = _sermon.ImageUrl;
                string realfilename = files.Where(i => i.Contains(filename)).FirstOrDefault();
                if (realfilename != null)
                {
                    fullpath = Path.Combine(Server.MapPath("~/Content/Images/"), realfilename);
                    if (System.IO.File.Exists(fullpath))
                    {
                        System.IO.File.Delete(fullpath);
                        var ImgMessage = $"the image:{fullpath} was also removed";
                    }
                }
            }
            if (_sermon != null)
            {

                _sermonServices.GetSermons().Remove(_sermon);
                _context.SaveChanges();
                TempData["message"] = $"{_sermon.SermonTitle} was successfully deleted.{Environment.NewLine}";
            }
            return RedirectToAction("SermonList");
        }
        public ActionResult SermonList(int? page)
        {
            var pageSize = 10;
            var sermons = _sermonServices.GetSermons().ToList().ToPagedList(page ?? 1, pageSize);
            var slvm = new SermonListViewModel
            {
                Sermons = sermons
            };
            ViewBag.page = page;
            ViewBag.PageSize = pageSize;
            return View(slvm);
        }
        public ActionResult WorkerList(int? page)
        {
            var pageSize = 10;
            var workers = _workServ.GetWorkers().ToList().ToPagedList(page ?? 1, pageSize);
            //var workersbydept = workers.Where(w => w.Department.Name == name).ToList().ToPagedList(page ?? 1, pageSize);
            var wlvm = new WorkerListViewModel
            {
                Workers = workers
            };

            ViewBag.page = page;
            ViewBag.PageSize = pageSize;
            return View(wlvm);
        }
        [HttpGet]
        public ActionResult EventList(int? page)
        {
            var pageSize = 10;
            var events = _event.GetEvents().ToList().ToPagedList(page ?? 1, pageSize);
            var elvm = new EventListViewModel
            {
                Events = events
            };
            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;
            return View(elvm);
        }
        [HttpGet]
        public ActionResult EditEvent(int id)
        {
            var _eventt = _event.GetEventById(id);
            var eventype = _event.GetEvents();
            var _eventtype = _eventt.Eventtype;
            ViewBag.EventType = new SelectList(eventype, "Name", "Name", _eventtype.Name);
            var evm = new EventModel
            {
                EventType = _eventt.Eventtype.Name,
                EventDate = _eventt.EventDate,
                EventDescription = _eventt.EventDescription,
                EventLocation = _eventt.EventLocation,
                EventName = _eventt.EventName,
                EventTheme = _eventt.EventTheme,
                EventImageUrl = _eventt.EventImageUrl
            };
            return View(evm);
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult EditEvent(EventModel evm)
        {
            if (ModelState.IsValid)
            {
                var events = _event.GetEventById(evm.EventId);
                var eventype = _event.GetEventTypes().Where(s => s.Name == evm.EventType).FirstOrDefault();


                if (events != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(evm.EventImageFile.FileName);
                    string extension = Path.GetExtension(evm.EventImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    evm.EventImageUrl = fileName;
                    fileName = Path.Combine(Server.MapPath("~/Content/Images/"), fileName);

                    events.EventName = evm.EventName;
                    events.EventTheme = evm.EventTheme;
                    events.EventLocation = evm.EventLocation;
                    events.EventDescription = evm.EventDescription;
                    events.EventImageUrl = evm.EventImageUrl;
                    events.EventImageThumbnailUrl = evm.EventImageUrl;
                    events.EventDate = evm.EventDate;
                    if (evm.EventImageFile != null && evm.EventImageFile.ContentLength > 0)
                    {
                        evm.EventImageFile.SaveAs(fileName);
                    }
                    events.Eventtype = eventype;
                    _context.SaveChanges();
                    TempData["message"] = $"{events.EventName} was successfully edited.";
                }
                return RedirectToAction("EventList");
            }
            else
            {
                return View(evm);
            }
        }
        public ActionResult DeleteEvent(int Id)
        {
            var _event = _context.Events.Where(e => e.EventId == Id).FirstOrDefault();
            if (_event != null)
            {
                _context.Events.Remove(_event);
                _context.SaveChanges();
                TempData["message"] = $"{_event.EventName} was successfully deleted.{Environment.NewLine}";
            }
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult SermonCategoryList()
        {
            var sermonCategories = _sermonCategory.GetSermonCategories();
            var sclvm = new SermonCategoryViewModel
            {
                SermonCategories = sermonCategories
            };
            return View(sclvm);
        }
        [HttpGet]
        public ActionResult EventTypeList()
        {
            var eventtypes = _event.GetEventTypes();
            var sclvm = new EventTypeListViewModel
            {
                EventTypes = eventtypes
            };
            return View(sclvm);
        }
        public ActionResult DeleteSermonCategory(int Id)
        {
            var _sermoncategory = _context.SermonCategories.Where(sc => sc.CatId == Id).FirstOrDefault();
            if (_sermoncategory != null)
            {
                _context.SermonCategories.Remove(_sermoncategory);
                _context.SaveChanges();
                TempData["message"] = $"{_sermoncategory.SermonName} was successfully deleted.";

            }
            return RedirectToAction("SermonCategoryList");
        }
 
    

    
        [HttpGet]
        public ActionResult AddSermonCategory()
        {
            return View(new SermonCategoryViewModel());
        }
        [HttpPost]
        public ActionResult AddSermonCategory(SermonCategoryViewModel scvm)
        {
            if (ModelState.IsValid)
            {
                var existingcat = _sermonCategory.GetSermonCategories().Where(sc => sc.SermonName == scvm.SermonType.Trim()).FirstOrDefault();
                if (existingcat != null)
                {
                    ModelState.AddModelError("", "This Category name exist before");
                    return View(scvm);
                }
                var cat = new SermonCategory
                {
                    SermonName = scvm.SermonType,
                    Sermons = new List<Sermon>(),
                    SermonDescription = scvm.SermonDescription
                };
                _context.SermonCategories.Add(cat);
                _context.SaveChanges();

                TempData["message"] = string.Format("{0} has been saved.", scvm.SermonType);

                return RedirectToAction("SermonCategoryList");
            }
            else
            {

                return View(scvm);
            }
        }
        [HttpGet]
        public ActionResult AddEventType()
        {
            return View(new EventTypeModel());
        }

        [HttpPost]
        public ActionResult AddEventType(EventTypeModel scvm)
        {
            if (ModelState.IsValid)
            {
                var existingcat = _context.Eventtypes.Where(sc => sc.Name == scvm.Type.Trim()).FirstOrDefault();
                if (existingcat != null)
                {
                    ModelState.AddModelError("", "This Category name exist before");
                    return View(scvm);
                }
                var cat = new EventType
                {
                    Name = scvm.Type,
                    Events = new List<Event>(),
                    Description = scvm.Description
                };
                _context.Eventtypes.Add(cat);
                _context.SaveChanges();

                TempData["message"] = string.Format("{0} has been saved.", scvm.Type);

                return RedirectToAction("EventTypeList");
            }
            else
            {

                return View(scvm);
            }
        }
        [HttpGet]
        public ActionResult EditSermonCategory(int id)
        {
            var sermoncategory = _context.SermonCategories.Find(id);
            var scvm = new SermonCategoryModel
            {
                CatId = sermoncategory.CatId,
                SermonType = sermoncategory.SermonName,
                SermonDescription = sermoncategory.SermonDescription
            };
            return View(scvm);
        }
        [HttpGet]
        public ActionResult EditEventType(int id)
        {
            var evntType = _context.Eventtypes.Find(id);
           // var eventtype = _event.GetEventById(id);
            var scvm = new EventTypeModel
            {
                ETId = evntType.ETId,
                Type = evntType.Name,
                Description = evntType.Description
            };
            return View(scvm);
        }
        [HttpPost]
        public ActionResult EditSermonCategory(SermonCategoryModel scvm)
        {
            if (ModelState.IsValid)
            {
                var sermoncategory = _context.SermonCategories.Where(sc => scvm.CatId == scvm.CatId).FirstOrDefault();
                if (sermoncategory != null)
                {
                    sermoncategory.SermonName = scvm.SermonType;
                    sermoncategory.SermonDescription = scvm.SermonDescription;
                    _context.SaveChanges();
                    TempData["message"] = $"{sermoncategory.SermonName} was successfully edited.";
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View(scvm);
            }
        }

             [HttpPost]
        public ActionResult EditEventType(EventTypeModel scvm)
        {
            if (ModelState.IsValid)
            {
                var eventtype = _context.Eventtypes.Where(sc => scvm.ETId == scvm.ETId).FirstOrDefault();
                if (eventtype != null)
                {
                    eventtype.Name = scvm.Type;
                    eventtype.Description = scvm.Description;
                    _context.SaveChanges();
                    TempData["message"] = $"{eventtype.Name} was successfully edited.";
                }
                return RedirectToAction("EventTypeList");
            }
            else
            {
                return View(scvm);
            }

        }
       
        public ActionResult DepartmentList(int? page)
        {
            var pageSize = 10;
            var depts = _dtservice.GetDepartments().ToList().ToPagedList(page ?? 1, pageSize);
            var dcvm = new DeptListViewModel { Departments = depts };
            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;
            return View(dcvm);
        }
        [HttpGet]
        public ActionResult AddDept()
        {
            return View(new DepartmentModel());
        }


        [ValidateInput(false)]
        [HttpPost]
        public ActionResult AddDept(DepartmentModel dcvm)
        {
            if (ModelState.IsValid)
            {
                var existingdept = _context.Departments.Where(t => t.DeptName == dcvm.DeptName.Trim()).FirstOrDefault();


                if (existingdept != null)
                {
                    ModelState.AddModelError("", $"A department with the name {dcvm.DeptName} already exists");
                    return View(dcvm);
                }
                string fileName = Path.GetFileNameWithoutExtension(dcvm.ImageFile.FileName);
                string extension = Path.GetExtension(dcvm.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                dcvm.ImageUrl = fileName;
                fileName = Path.Combine(Server.MapPath("~/Content/Images/"), fileName);
                dcvm.ImageFile.SaveAs(fileName);


                //string deptleader = Path.GetFileNameWithoutExtension(dcvm.DeptLeaderImageFile.FileName);
                //string deptleaderextn = Path.GetExtension(dcvm.DeptLeaderImageFile.FileName);
                //deptleader = deptleader + DateTime.Now.ToString("yymmssfff") + deptleaderextn;
                //dcvm.DeptLeaderIamgeUrl = fileName;
                //deptleader = Path.Combine(Server.MapPath("~/Content/Images/"), deptleader);
                //dcvm.DeptLeaderImageFile.SaveAs(deptleader);


                var dept = new Department
                {
                    DeptName = dcvm.DeptName,
                    Description = dcvm.Description,
                    DeptLocation = dcvm.DeptLocation,
                    // MeetingDay = dcvm.DeptMeeting,
                    ImageUrl = dcvm.ImageUrl,
                    ImageThumbnailUrl = dcvm.ImageUrl,
                    DeptLeaderName = dcvm.DeptLeaderName,
                    //LeaderImageUrl=dcvm.DeptLeaderIamgeUrl,
                    //LeaderImageThumbnailUrl=dcvm.DeptLeaderIamgeUrl

                };
                _context.Departments.Add(dept);
                _context.SaveChanges();

                TempData["message"] = string.Format("{0} has been saved.", dcvm.DeptName);



                return RedirectToAction("DepartmentList");
            }
            else
            {

                return View(dcvm);
            }
        }
        [HttpGet]
        public ActionResult EditDept(int id)
        {
          // var _dept = _context.Departments.Find(id);
            var _dept = _dtservice.GetDepartmentById(id);
            var dvm = new DepartmentModel
            {
                DeptLeaderName = _dept.DeptLeaderName,
                // DeptLeaderIamgeUrl=_dept.LeaderImageUrl,
                // DeptMeeting=_dept.MeetingDay,
                DeptLocation = _dept.DeptLocation,
                DeptName = _dept.DeptName,
                Description = _dept.Description,
                ImageUrl = _dept.ImageUrl,
            };
            return View(dvm);
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult EditDept(DepartmentModel dvm)
        {
            if (ModelState.IsValid)
            {
               // var _depts = _context.Departments.Find(dvm.DeptId);
             // var _depts = _dtservice.GetDepartmentById(dvm.DeptId);

                var _depts = _dtservice.UpdateDept(dvm);
                if (_depts != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(dvm.ImageFile.FileName);
                    string extension = Path.GetExtension(dvm.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    dvm.ImageUrl = fileName;
                    fileName = Path.Combine(Server.MapPath("~/Content/Images/"), fileName);



                    //string deptleader = Path.GetFileNameWithoutExtension(dvm.DeptLeaderImageFile.FileName);
                    //string deptleaderextn = Path.GetExtension(dvm.DeptLeaderImageFile.FileName);
                    //deptleader = deptleader + DateTime.Now.ToString("yymmssfff") + deptleaderextn;
                    //dvm.DeptLeaderIamgeUrl = fileName;
                    //deptleader = Path.Combine(Server.MapPath("~/Content/Images/"), deptleader);

                 //   var result = _dtservice.UpdateDept(dvm);

                    //_depts.DeptName = dvm.DeptName;
                    //_depts.Description = dvm.Description;
                    //_depts.DeptLocation = dvm.DeptLocation;
                    ////_depts.MeetingDay = dvm.DeptMeeting;
                    //_depts.ImageUrl = dvm.ImageUrl;
                    //_depts.ImageThumbnailUrl = dvm.ImageUrl;
                    //_depts.DeptLeaderName = dvm.DeptLeaderName;
                    //_depts.LeaderImageUrl = dvm.DeptLeaderIamgeUrl;
                    //_depts.LeaderImageThumbnailUrl = dvm.DeptLeaderIamgeUrl;


                    if (dvm.ImageFile != null && dvm.ImageFile.ContentLength > 0)
                    {
                        dvm.ImageFile.SaveAs(fileName);
                    }
                    //if (dvm.DeptLeaderImageFile != null && dvm.DeptLeaderImageFile.ContentLength > 0)
                    //{
                    //    dvm.ImageFile.SaveAs(deptleader);
                    //}
                    //_context.SaveChanges();
                    TempData["message"] = $"{dvm.DeptName} was successfully edited.";
                }



                //_mailService.Send("A new department added", $"Department {dvm.DeptName}, and the Department Leader{dvm.DeptLeaderName} ");
                return RedirectToAction("DepartmentList");
            }
            else
            {
                return View(dvm);
            }
        }

        //[HttpGet]
        //public ActionResult UserList()
        //{
        //    List<IUser> users = _uow.Users.UserList;
        //    List<User> userlist = users.Select(c => (User)c).ToList();
        //    var ulvm = new UserListViewModel
        //    {
        //        Users = userlist
        //    };
        //    return View(ulvm);
        //}
    }
}

