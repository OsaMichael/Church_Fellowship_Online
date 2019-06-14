using GospelWorld.Atrributes;
using GospelWorld.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GospelWorld.Models
{
    public class SermonModel
    {
        public int SermId { get; set; }
        public int CatId { get; set; }
        [Display(Name = "Sermon Title")]
        public string SermonTitle { get; set; }
        [Display(Name = "Sermon Text")]
        public string SermonText { get; set; }
        [Display(Name = "Sermon Date")]
        public DateTime SermonDate { get; set; }
        [Display(Name = "Sermon Brief")]
        public string ShortDescription { get; set; }
        [Display(Name = "Sermon Detail")]
        public string LongDescription { get; set; }
        [Display(Name = "Preacher's Name")]
        public string PreacherName { get; set; }
        [Display(Name = "Preacher's Image")]
        public string ImageUrl { get; set; }
        [FileTypes("jpg,jpeg,png")]
        public HttpPostedFileBase ImageFile { get; set; }
        public string ImageThumbnailUrl { get; set; }
    
        //[FileTypes("mp4,3gp,avi,mov,webm")]
        //public string SermonvideoUrl { get; set; }
        //public HttpPostedFileBase SermonvideoFile { get; set; }

        [Display(Name = "Category")]
        public string SermonCategoryName { get; set; }
        public virtual SermonCategoryModel SermonCategory { get; set; }
        public bool IsLike { get; set; }
        public bool Done { get; set; } = false;

        //public IEnumerable<SermonModel> Sermons { get; set; }
        //public IEnumerable<SermonCategory> SermonCategorss { get; set; }
        //public string SermonCat { get; set; }
        //  public SermonViewModel sermonViews { get; set; }

        public SermonModel()
        {
            new SermonCategoryModel();
        }

        public SermonModel(Sermon sermon)
        {
            this.Assign(sermon);
            SermonCategory = new SermonCategoryModel();
        }

        public Sermon Create(SermonModel model)
        {
            return new Sermon
            {
                SermonText = model.SermonText,
                   IsLiked  = model.IsLike,
                    LongDescription = model.LongDescription,
                     PreacherName = model.PreacherName,
                       SermonDate = model.SermonDate,
                        ShortDescription =model.ShortDescription,
                         SermonTitle = model.SermonTitle,
                           ImageThumbnailUrl = model.ImageThumbnailUrl
            };
        }

        public Sermon Edit(Sermon entity, SermonModel model)
        {
            entity.SermonTitle = model.SermonTitle;
            entity.ShortDescription = model.ShortDescription;
            entity.PreacherName = model.PreacherName;
            entity.LongDescription = model.LongDescription;
            entity.IsLiked = model.IsLike;
            entity.CatId = model.SermId;
            entity.SermonText = model.SermonText;
            entity.SermonDate = model.SermonDate;
               
            return entity;
        }

    }
}