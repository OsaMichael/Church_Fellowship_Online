using GospelWorld.Interface;
using GospelWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GospelWorld.Managers
{
    public class MemberServices : IMemberServices
    {
        private ApplicationDbContext _context;

        public MemberServices(ApplicationDbContext context)
        {
            this._context = context;
        }
        public bool CreateMemb(MemberModel model)
        {
            try
            {
                var isExist = _context.Members.Where(x => x.PhoneNumber == model.PhoneNumber).FirstOrDefault();
                if (isExist != null) throw new Exception("Phone number  already exist");

                // var dept = _context.Departments.ToList().Select(r =>r.DeptName);


                var entity = model.Create(model);
                _context.SaveChanges();


            }
            catch (Exception xe)
            {
                throw xe;
            }

            return true;
        }
        public List<MemberModel> GetMembers()
        {
            var entities = _context.Members.ToList();
            var models = entities.Select(c => new MemberModel(c)
            {

                 Address = c.Address,
                  DateOfBirth = DateTime.Now,
                PhoneNumber = c.PhoneNumber,
                  FirstName = c.FirstName,
                  LastName = c.LastName,
                   Married = c.Married,
                    OtherName = c.OtherName,
                  Profession = c.Profession,
                   SpouseName = c.SpouseName,
                    MemberImageUrl = c.MemberImageUrl,
                    //MemeberImageThumbnailUrl = c.MemeberImageThumbnailUrl


            }
            ).ToList();
            return models;
        }
        public bool UpdateMemb(MemberModel model)
        {
            //var isExist = _context.Departments.Where(n => n.DeptId == model.DeptId).FirstOrDefault();
            //if (isExist == null) throw new Exception("user not found");

            var deptInDb = _context.Members.Find(model.MembId);
            if (deptInDb == null) throw new Exception("not found");

            var entity = model.Edit(deptInDb, model);
            _context.Entry(entity);
            _context.SaveChanges();
            return true;

        }

        public MemberModel GetMemberById(int id)
        {

            var entity = _context.Members.Where(x => x.MembId == id).FirstOrDefault();
            if (entity == null) throw new Exception(" user Id not found");
            return new MemberModel(entity);

        }
        public bool DeleteMember(int id)
        {
            var entity = _context.Members.Where(x => x.MembId == id).FirstOrDefault();
            if (entity == null) throw new Exception("not found");

            _context.Members.Remove(entity);
            _context.SaveChanges();
            return true;
        }
    }
}