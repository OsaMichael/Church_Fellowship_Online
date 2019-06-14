using GospelWorld.Atrributes;
using GospelWorld.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GospelWorld.Models
{
    public class WorkerModel
    {
        public int WorkId { get; set; }
        public int? DeptId { get; set; }
        public string WorkerName { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Othe Names")]
        public string OtherName { get; set; }
        public string ImageThumbnailUrl { get; set; }
        [Display(Name = "House Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }


        [FileTypes("jpg,jpeg,png")]
        public HttpPostedFileBase ImageFile { get; set; }


        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }
        public virtual DepartmentModel Department { get; set; }
        public virtual ICollection<AttendanceModel> Attendancss { get; set; }


        public WorkerModel()
        {
            new DepartmentModel();
        }

        public WorkerModel(Worker worker)
        {
            this.Assign(worker);
            Department = new DepartmentModel();
        }

        public Worker Create(WorkerModel model)
        {
            return new Worker
            {
                WorkerName = model.FirstName + " " + model.LastName,
                Address = model.Address,
                DeptId = model.DeptId,
                 PhoneNumber = model.PhoneNumber,
                  FirstName = model.FirstName,
                 LastName = model.LastName,
                 OtherName = model.OtherName,
                    ImageUrl = model.ImageUrl,
                ImageThumbnailUrl = model.ImageUrl,
            
            };
        }

        public Worker Edit(Worker entity, WorkerModel model)
        {

            entity.OtherName = model.OtherName;
            entity.LastName = model.LastName;
            entity.PhoneNumber = model.PhoneNumber;
            entity.FirstName = model.FirstName;
            entity.DeptId = model.DeptId;
            entity.WorkId = model.WorkId;
            return entity;
        }
    }
}