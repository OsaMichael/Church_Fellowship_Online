using GospelWorld.Interface;
using GospelWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GospelWorld.Managers
{
    public class SermonServices : ISermonServices
    {
        private ApplicationDbContext _context;

        public SermonServices(ApplicationDbContext context)
        {
            this._context = context;
        }

        public bool CreatSermon(SermonModel model)
        {
            try
            {          
                //var isExist = _context.Sermons.Where(x => x. == model.DeptName).FirstOrDefault();
                //if (isExist != null) throw new Exception("Department already exist");
             
                //since a message can be preach twice
                var entity = model.Create(model);
                _context.SaveChanges();

            }
            catch (Exception xe)
            {
                throw xe;
            }

            return true;
        }
        public List<SermonModel> GetSermons()
        {
            var entities = _context.Sermons.ToList();
            var models = entities.Select(c => new SermonModel(c)
            {
         LongDescription = c.LongDescription,
          PreacherName = c.PreacherName,
           SermonTitle = c.SermonTitle,
            ShortDescription = c.ShortDescription,
             SermonDate = c.SermonDate,
               SermonText = c.SermonText,
                 SermonCategoryName = c.SermonCategory.SermonName,
                  IsLike = c.IsLiked
                 
            }
            ).ToList();
            return models;
        }

        public List<SermonViewModel> GetSermonViewModels()
        {
            var tttt = _context.Sermons.ToList();
            var models = tttt.Select(c => new SermonViewModel(c)).ToList();
            return models;
        }
        public bool UpdateSerm(SermonModel model)
        {
            //var isExist = _context.Departments.Where(n => n.DeptId == model.DeptId).FirstOrDefault();
            //if (isExist == null) throw new Exception("user not found");

            var deptInDb = _context.Sermons.Find(model.SermId);
            if (deptInDb == null) throw new Exception("not found");

            var entity = model.Edit(deptInDb, model);
            _context.Entry(entity);
            _context.SaveChanges();
            return true;

        }
        public SermonModel GetSermonById(int id)
        {

            var entity = _context.Sermons.Where(x => x.SermId == id).FirstOrDefault();
            if (entity == null) throw new Exception(" user Id not found");
            return new SermonModel(entity);

        }
        public bool SermonsbyCategory(string name)
        {
            var sermonscategory = _context.Sermons.Where(vv => vv.SermonCategory.SermonName == name);

            //var svm = new SermonViewModel
            //{
            //    Sermons = sermonscategory,
            //    SermonCat = name
            //};
            return true;
        }
        public bool DeleteSermon(int id)
        {
            var entity = _context.Sermons.Where(x => x.SermId == id).FirstOrDefault();
            if (entity == null) throw new Exception("not found");

            _context.Sermons.Remove(entity);
            _context.SaveChanges();
            return true;
        }
    }
}