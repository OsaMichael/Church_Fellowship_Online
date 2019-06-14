using GospelWorld.Atrributes;
using GospelWorld.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GospelWorld.Models
{
    public class DepartmentModel
    {
        public int DeptId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "Department Name")]
        public string DeptName { get; set; }

        [Display(Name = "Department Leader's Name")]
        public string DeptLeaderName { get; set; }
        [Display(Name = "Department Leader's Image")]
        public string DeptLeaderIamgeUrl { get; set; }
        [Display(Name = "jpg,jpeg,png")]
        public HttpPostedFileBase DeptLeaderImageFile { get; set; }
        [Display(Name = "Department Description")]
        public string Description { get; set; }
        [Display(Name = "Department Meeting Day and Time")]
        public string DeptMeeting { get; set; }
        [Display(Name = "Department Meeting location")]
        public string DeptLocation { get; set; }
        [Display(Name = "Department Image")]
        public string ImageUrl { get; set; }
        public ICollection<WorkerModel> Workers { get; set; }
      //  public IEnumerable<Department> Departments { get; set; }
        //[FileSize(102400)]
        [FileTypes("jpg,jpeg,png")]
        public HttpPostedFileBase ImageFile { get; set; }
        public string LeaderImageThumbnailUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public bool Done { get; set; } = false;


        public DepartmentModel()
        {
           
        }

        public DepartmentModel (Department department)
        {
            this.Assign(department);
        }

        public Department Create (DepartmentModel model)
        {
            return new Department
            {
                 DeptName = model.DeptName,
                 LeaderImageUrl = model.DeptLeaderIamgeUrl,
                LeaderImageThumbnailUrl = model.LeaderImageThumbnailUrl,
                ImageThumbnailUrl = model.ImageThumbnailUrl,
                //DeptLeaderImageFile = model.DeptLeaderImageFile,
                DeptLeaderName = model.DeptLeaderName,
                DeptLocation = model.DeptLocation,
                DeptMeeting = model.DeptMeeting,
         
                Description = model.Description,
                Done = model.Done,
               
                ImageUrl = model.ImageUrl,
                //Workers = model.Workers,
            };
        }

        public Department Edit(Department entity, DepartmentModel model)
        {
         
            entity.ImageThumbnailUrl = model.ImageThumbnailUrl;
            entity.ImageUrl = model.ImageUrl;
            entity.LeaderImageThumbnailUrl = model.LeaderImageThumbnailUrl;
            entity.LeaderImageUrl = model.DeptLeaderIamgeUrl;
            entity.Description = model.Description;
            entity.DeptMeeting = model.DeptMeeting;
            entity.DeptLocation = model.DeptLocation;
            entity.DeptLeaderName = model.DeptLeaderName;
            entity.DeptId = model.DeptId;
          //  entity.Workers = model.Workers;

            return entity;
        }
    }
}