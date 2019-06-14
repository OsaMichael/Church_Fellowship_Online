using GospelWorld.Interface;
using GospelWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GospelWorld.Managers
{
    public class EventServices : IEventServices
    {
        private ApplicationDbContext _context;

        public EventServices(ApplicationDbContext context)
        {
            this._context = context;
        }

        public bool CreateEvent(EventModel model)
        {
            try
            {
                var isExist = _context.Events.Where(x => x.EventName == model.EventName && x.EventTheme == model.EventTheme).FirstOrDefault();
                if (isExist != null) throw new Exception("Event already exist");

                var entity = model.Create(model);
                _context.SaveChanges();

            }
            catch (Exception xe)
            {
                throw xe;
            }

            return true;
        }
        public List<EventModel> GetEvents()
        {
            var entities = _context.Events.ToList();
            var models = entities.Select(c => new EventModel(c)
            {

             EventName = c.EventName,
             EventDescription = c.EventDescription,
             EventTheme = c.EventTheme,
             EventLocation = c.EventLocation,
             EventImageUrl = c.EventImageUrl
                          
            }
            ).ToList();
            return models;
        }
        public List<EventTypeModel> GetEventTypes()
        {
            var entities = _context.Eventtypes.ToList();
            var models = entities.Select(c => new EventTypeModel(c)
            {

               Description = c.Description,
                 Name = c.Name,
                ETId = c.ETId,
                
            }
            ).ToList();
            return models;
        }
        public bool UpdateEvent(EventModel model)
        {
            //var isExist = _context.Departments.Where(n => n.DeptId == model.DeptId).FirstOrDefault();
            //if (isExist == null) throw new Exception("user not found");

            var deptInDb = _context.Events.Find(model.EventId);
            if (deptInDb == null) throw new Exception("not found");

            var entity = model.Edit(deptInDb, model);
            _context.Entry(entity);
            _context.SaveChanges();
            return true;

        }

        public EventModel GetEventById(int id)
        {

            var entity = _context.Events.Where(x => x.EventId == id).FirstOrDefault();
            if (entity == null) throw new Exception(" user Id not found");
            return new EventModel(entity);

        }
        public bool DeleteEvent(int id)
        {
            var entity = _context.Events.Where(x => x.EventId == id).FirstOrDefault();
            if (entity == null) throw new Exception("not found");

            _context.Events.Remove(entity);
            _context.SaveChanges();
            return true;
        }

    }
}