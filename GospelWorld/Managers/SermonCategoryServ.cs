using GospelWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GospelWorld.Managers
{
    public class SermonCategoryServ : ISermonCategoryServ
    {
        private ApplicationDbContext _context;
        public SermonCategoryServ(ApplicationDbContext context)
        {
            this._context = context;
        }
        public List<SermonCategoryModel> GetSermonCategories()
        {
            var entities = _context.SermonCategories.ToList();
            var models = entities.Select(c => new SermonCategoryModel(c)
            {
             SermonDescription = c.SermonDescription,
              SermonName = c.SermonName,
               SermonType = c.SermonType,
                SermonCat = c.SermonCat
                

            }
            ).ToList();
            return models;
        }

        //public List<SermonCategoryModel> GetSermonCategoryList()
        //{
        //    var entities = _context.SermonCategories.ToList();
        //    var models = entities.Select(c => new SermonCategoryModel(c)
        //    {
        //        SermonDescription = c.SermonDescription,
        //        SermonName = c.SermonName,
        //        SermonType = c.SermonType,
        //        SermonCat = c.SermonCat


        //    }
        //    ).ToList();
        //    return models;
        //}
    }
}