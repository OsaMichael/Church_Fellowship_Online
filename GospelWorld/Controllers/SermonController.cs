using GospelWorld.Entities;
using GospelWorld.Interface;
using GospelWorld.Models;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GospelWorld.Controllers
{
    public class SermonController : Controller
    {
    private ISermonServices  _sermonServices;
        private ApplicationDbContext _context;
        public SermonController (ISermonServices sermonServices)
        {
            _sermonServices = sermonServices;
            _context = new ApplicationDbContext();

        }

        // GET: Sermon
        public ActionResult Index()
        {
            var sermon = _sermonServices.GetSermons().OrderBy(n =>n.SermonDate);
            ViewBag.SermonCategory = _context.SermonCategories.ToList().Select(r => new SermonCategoryModel(r)
            {
                  SermonDescription = r.SermonDescription,
                   SermonName = r.SermonName
            });

            var sermonCat = _context.SermonCategories.ToList();
         
            var svm = new  SermonViewModel
            {
                 Sermons = sermon,
                SermonCategorss = sermonCat,
                SermonCat = ""

            };
            return View(svm);
        }

        public ActionResult BibleTestss(SermonModel model)
        {
            var results = _sermonServices.GetAllBibleTest(model);
            
            return View(results);


        }

        public ActionResult PrintPdf (SermonModel model)
        {
            var svm = new SermonIndexViewModel
            {
                sermon = model
            };
            var pdfView = new ViewAsPdf("SermonDetails", svm)
            {
                FileName = "File.pdf",
                PageSize = Rotativa.Options.Size.A4,
                PageMargins =
                {
                    Left=0,
                    Right=0
                }
            };
            return pdfView;
        }
        public ActionResult SermonsbyCategory(string name)
        {
            var sermonscategory = _sermonServices.GetSermons().Where(vv => vv.SermonCategory.SermonName == name);

            var svm = new SermonViewModel
            {
               Sermons = sermonscategory,
                SermonCat = name
            };
            return View("Index", svm);
        }
        public ActionResult SermonDetails(int id = 0)
        {

            var _sermon = _context.Sermons.Find(id);
            var result = _sermonServices.GetSermonById(id);
            var sermon = _sermon;
            //var sivm = new SermonIndexViewModel
            //{
            //    sermon = sermon,
            //    ReturnUrl = returnurl
            //};
            return View(sermon);
        }
    }
}