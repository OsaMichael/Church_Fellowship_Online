using GospelWorld.Entities;
using GospelWorld.Interface;
using GospelWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GospelWorld.Managers
{
    public class DepartmentService : IDepartmentService
    {

        private ApplicationDbContext _context;

        public DepartmentService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public bool CreateDept(DepartmentModel model)
        {
            try
            {
                var isExist = _context.Departments.Where(x => x.DeptName == model.DeptName).FirstOrDefault();
                if (isExist != null) throw new Exception("Department already exist");

                var entity = model.Create(model);
                _context.SaveChanges();
 
            }
            catch (Exception xe)
            {
                throw xe;
            }

            return true;
        }

        public List<DepartmentModel> GetDepartments()
        {
            var entities = _context.Departments.ToList();
            var models = entities.Select(c => new DepartmentModel(c)
            {
                DeptLeaderIamgeUrl = c.LeaderImageUrl,
                //DeptLeaderImageFile = c.DeptLeaderImageFile,
                DeptLeaderName = c.DeptLeaderName,
                DeptLocation = c.DeptLocation,
                DeptName = c.DeptName,
                Description = c.Description,
                //Workers = c.Workers,
                 DeptMeeting = c.DeptMeeting,
                  
            }
            ).ToList();
            return models;
        }

        public DepartmentModel UpdateDept (DepartmentModel model)
        {
            //var isExist = _context.Departments.Where(n => n.DeptId == model.DeptId).FirstOrDefault();
            //if (isExist == null) throw new Exception("user not found");

            var deptInDb = _context.Departments.Find(model.DeptId);
            if (deptInDb == null) throw new Exception("not found");

            var entity = model.Edit(deptInDb, model);
            _context.Entry(entity);
            _context.SaveChanges();
            return model;
         
        }
        public DepartmentModel GetDepartmentById(int id)
        {
  
                var entity = _context.Departments.Where(x => x.DeptId == id).FirstOrDefault();
                if (entity == null) throw new Exception(" user Id not found");
                return new DepartmentModel(entity);

        }

      public DepartmentModel DepatDetails(int id)
        {
            var entity = _context.Departments.FirstOrDefault(s => s.DeptId == id);
            if (entity == null) throw new Exception("id not found");

            var reult = new DepartmentModel
            {

                DeptName = entity.DeptName,
                 DeptLeaderIamgeUrl = entity.LeaderImageUrl,
                LeaderImageThumbnailUrl = entity.LeaderImageThumbnailUrl,
                ImageThumbnailUrl = entity.ImageThumbnailUrl,
                //DeptLeaderImageFile = entity.DeptLeaderImageFile,
                DeptLeaderName = entity.DeptLeaderName,
                DeptLocation = entity.DeptLocation,
                DeptMeeting = entity.DeptMeeting,

                Description = entity.Description,
                Done = entity.Done,
              
                ImageUrl = entity.ImageUrl,
                //Workers = entity.Workers,
            };
            return reult;
        }

      public bool DeleteDept (int id)
        {
            var entity = _context.Departments.Where(x => x.DeptId == id).FirstOrDefault();
            if (entity == null) throw new Exception("not found");

            _context.Departments.Remove(entity);
            _context.SaveChanges();
            return true;
        }
    }
}