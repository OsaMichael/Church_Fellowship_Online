//using GospelWorld.Entities;
//using GospelWorld.Interface;
//using GospelWorld.Managers;
using GospelWorld.Entities;
using GospelWorld.Interface;
using GospelWorld.Managers;
using GospelWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GospelWorld.Controllers
{
    public class NavigationController : Controller
    {
        private readonly ApplicationDbContext _context;
        private ISermonServices _sermonServices;
        private ISermonCategoryServ _categoryServ;
        public NavigationController(ApplicationDbContext context, ISermonServices sermon, ISermonCategoryServ categoryServ)
        {
            _context = context;
            _sermonServices = sermon;
            _categoryServ = categoryServ;
        }
        public PartialViewResult SermonMenu(string sermoncategory = null)
        {
            ViewBag.SelectedSermon = sermoncategory;
            List<SermonCategory> sermoncategories = _context.SermonCategories.ToList();
            return PartialView(sermoncategories);
        }
        public PartialViewResult MediaMenu(string gallery = null)
        {
            ViewBag.SelectedPhotos = gallery;
            IEnumerable<Sermon> galleries = _context.Sermons;
            return PartialView(galleries);

        }
        public PartialViewResult Events(string gallery = null)
        {
            ViewBag.SelectedPhotos = gallery;
            IEnumerable<Sermon> galleries = _context.Sermons;
            return PartialView(galleries);

        }
    }
}