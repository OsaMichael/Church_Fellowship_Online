using GospelWorld.Interface;
using GospelWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GospelWorld.Managers
{
    public class WorkerServices : IWorkerServices
    {
        private ApplicationDbContext _context;

        public WorkerServices(ApplicationDbContext context)
        {
            this._context = context;
        }
        public bool CreateWorker(WorkerModel model)
        {
            try
            {
                var isExist = _context.Workers.Where(x => x.PhoneNumber == model.PhoneNumber).FirstOrDefault();
                if (isExist != null) throw new Exception("Phone number  already exist");

             // var dept = _context.Departments.ToList().Select(r =>r.DeptName);
                

                var entity = model.Create(model);
                _context.Workers.Add(entity);
                _context.SaveChanges();

               
            }
            catch (Exception xe)
            {
                throw xe;
            }

            return true;
        }

        public List<WorkerModel> GetWorkers()
        {
            var entities = _context.Workers.ToList();
            var models = entities.Select(c => new WorkerModel(c)
            {

               DeptId = c.DeptId,
                Address = c.Address,
                 FirstName = c.FirstName,
                  LastName = c.LastName,
                   OtherName = c.OtherName,
                    PhoneNumber = c.PhoneNumber,
                    

            }
            ).ToList();
            return models;
        }
        public bool UpdateWork(WorkerModel model)
        {
            //var isExist = _context.Departments.Where(n => n.DeptId == model.DeptId).FirstOrDefault();
            //if (isExist == null) throw new Exception("user not found");

            var deptInDb = _context.Workers.Find(model.WorkId);
            if (deptInDb == null) throw new Exception("not found");

            var entity = model.Edit(deptInDb, model);
            _context.Entry(entity);
            _context.SaveChanges();
            return true;

        }

        public WorkerModel GetWorkerById(int id)
        {

            var entity = _context.Workers.Where(x => x.WorkId == id).FirstOrDefault();
            if (entity == null) throw new Exception(" user Id not found");
            return new WorkerModel(entity);

        }
        public bool DeleteWorker(int id)
        {
            var entity = _context.Workers.Where(x => x.WorkId == id).FirstOrDefault();
            if (entity == null) throw new Exception("not found");

            _context.Workers.Remove(entity);
            _context.SaveChanges();
            return true;
        }
    }
}